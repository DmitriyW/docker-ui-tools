using Docker.Abstractions.Services;
using Docker.GUI.Extentions;
using Docker.Models;

namespace Docker.GUI.Pages;

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

        SetIvents();

        RefreshImagesAsync();
    }

    private void SetIvents()
    {
        this.searchImage.TextChanged += SearchImage_TextChanged;
        this.checkAll.Click += CheckAll_Click;
        this.imageList.ItemChecked += ImageList_ItemChecked;
        this.imageList.MouseClick += ImageList_MouseClick;
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
            if (_images.Count > selectedContainer.Index)
            {
                indexes.Add(selectedContainer.Index);
                _selectedImages.Add(_images[selectedContainer.Index].ID);
            }
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
            await imageService.GetImagesAsync(new Progress<IEnumerable<DockerImage>>(getImages));
        }
        else
        {
            ViewImages();
            this.refreshImageList.Enabled = true;
        }
    }

    private IEnumerable<DockerImage> FilteredList() =>
        filter.Length > 0 ? _images.Where(c => c.Repository.IndexOf(this.searchImage.Text) == 0) : _images;

    private void ViewImages()
    {
        var list = new List<ListViewItem>();

        foreach (var item in FilteredList())
        {
            var lvi = new ListViewItem();
            lvi.Checked = _selectedImages.Contains(item.ID);
            lvi.SubItems.Add(item.Repository);
            lvi.SubItems.Add(item.Tag);
            lvi.SubItems.Add(item.CreatedSince);
            lvi.SubItems.Add(item.Size);
            list.Add(lvi);
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (i < this.imageList.Items.Count)
            {
                if (!this.imageList.Items[i].Compare(list[i]))
                {
                    this.imageList.Items[i] = list[i];
                }
            }
            else
            {
                this.imageList.Items.Add(list[i]);
            }
        }
        if (list.Count < this.imageList.Items.Count)
        {
            while (this.imageList.Items.Count != list.Count)
            {
                this.imageList.Items.RemoveAt(list.Count);
            }
        }
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
            await imageService.DeleteImageAsync(new Progress<string>(deleteResult), FilteredList().ToList()[index].ID);
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
        await imageService.DeleteImageAsync(new Progress<string>(deleteResult), FilteredList().ToList()[index].ID);
    }

    private void copyImageId_Click(object sender, EventArgs e)
    {
        var focusedItem = this.imageList.FocusedItem;
        var index = focusedItem.Index;

        Clipboard.SetText(FilteredList().ToList()[index].ID);
    }
}
