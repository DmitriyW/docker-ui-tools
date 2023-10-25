using Docker.Abstractions.Services;
using Docker.Models;

namespace Docker.GUI;

public partial class ImagePage : UserControl
{
    private IList<DockerImage> _images = new List<DockerImage>();
    private readonly IImageService imageService;
    private string filter = string.Empty;
    private IList<string> _selectedImages = new List<string>();

    public ImagePage(IImageService imageService)
    {
        this.imageService = imageService;
        InitializeComponent();

        this.searchImage.TextChanged += SearchImage_TextChanged;
        this.checkAll.Click += CheckAll_Click;
        this.imageList.ItemChecked += ImageList_ItemChecked;
        this.imageList.MouseClick += ImageList_MouseClick;

        RefreshImagesAsync();
    }

    private void ImageList_MouseClick(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var focusedItem = this.imageList.FocusedItem;
            if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
            {
                this.imageContextMenu.Show(Cursor.Position);
            }
        }
    }

    private void ImageList_ItemChecked(object? sender, ItemCheckedEventArgs e)
    {
        disableActionBtnState();
        if (this.imageList.CheckedItems.Count == this.imageList.Items.Count)
        {
            this.checkAll.Checked = true;
        }
        else
        {
            this.checkAll.Checked = false;
        }
        actionBtnState();
    }

    private void actionBtnState()
    {
        if (GetSelectedIndexes().Any())
        {
            this.deleteImage.Enabled = true;
        }
        else
        {
            this.deleteImage.Enabled = false;
        }
    }

    private IEnumerable<int> GetSelectedIndexes()
    {
        _selectedImages.Clear();

        var indexes = new List<int>();
        foreach (ListViewItem selectedContainer in this.imageList.CheckedItems)
        {
            indexes.Add(selectedContainer.Index);
            _selectedImages.Add(_images[selectedContainer.Index].ID);
        }

        return indexes;
    }

    private void disableActionBtnState()
    {
        this.deleteImage.Enabled = false;
    }

    private void CheckAll_Click(object? sender, EventArgs e)
    {
        ChangeCheckboxStateForImages(this.checkAll.Checked);
    }

    private void ChangeCheckboxStateForImages(bool state)
    {
        foreach (ListViewItem item in this.imageList.Items)
        {
            item.Checked = state;
        }
    }

    private void SearchImage_TextChanged(object? sender, EventArgs e)
    {
        filter = this.searchImage.Text;
        RefreshImagesAsync(false);
    }

    private void refreshImageList_Click(object sender, EventArgs e)
    {
        this.refreshImageList.Enabled = false;
        RefreshImagesAsync();
    }

    private async Task RefreshImagesAsync(bool getFreshData = true)
    {
        if (getFreshData)
        {
            var getImages = new Action<IEnumerable<DockerImage>>(x =>
            {
                _images = x.ToList();
                ViewImages();
                this.refreshImageList.Enabled = true;
            });
            await imageService.GetImageAsync(new Progress<IEnumerable<DockerImage>>(getImages));
        }
        else
        {
            ViewImages();
            this.refreshImageList.Enabled = true;
        }
    }

    private void ViewImages()
    {
        var list = new List<ListViewItem>();
        imageList.Items.Clear();

        foreach (var item in filter.Length > 0 ? _images.Where(c => c.Repository.IndexOf(this.searchImage.Text) == 0) : _images)
        {
            var lvi = new ListViewItem();
            lvi.Checked = _selectedImages.Contains(item.ID);
            lvi.SubItems.Add(item.Repository);
            lvi.SubItems.Add(item.Tag);
            lvi.SubItems.Add(item.CreatedSince);
            lvi.SubItems.Add(item.Size);
            list.Add(lvi);
        }

        this.imageList.Items.AddRange(list.ToArray());
    }

    private void deleteImage_Click(object sender, EventArgs e)
    {
        DeleteImages();
    }

    private async Task DeleteImages()
    {
        var deleteResult = new Action<string>(x =>
        {
            RefreshImagesAsync();
        });
        foreach (int index in GetSelectedIndexes())
        {
            await imageService.DeleteContainerAsync(new Progress<string>(deleteResult), _images.ToList()[index].ID);
        }
    }

    private void deleteDockerImage_Click(object sender, EventArgs e)
    {
        var focusedItem = this.imageList.FocusedItem;
        var index = focusedItem.Index;
        DeleteImage(index);
    }

    private async Task DeleteImage(int index)
    {
        var deleteResult = new Action<string>(x =>
        {
            RefreshImagesAsync();
        });
        await imageService.DeleteContainerAsync(new Progress<string>(deleteResult), _images.ToList()[index].ID);
    }

    private void copyImageId_Click(object sender, EventArgs e)
    {
        var focusedItem = this.imageList.FocusedItem;
        var index = focusedItem.Index;

        Clipboard.SetText(_images.ToList()[index].ID);
    }
}
