using Docker.Abstractions.Services;
using Docker.GUI.Extentions;
using Docker.Models;

namespace Docker.GUI.Pages;

public partial class VolumePage : UserControl
{
    private IList<Volume> _volumes = new List<Volume>();
    private readonly IVolumeService volumeService;
    private string filter = string.Empty;
    private IList<string> _selectedVolumes = new List<string>();

    public VolumePage(IVolumeService volumeService)
    {
        this.volumeService = volumeService;
        InitializeComponent();

        SetIvents();

        RefreshVolumesAsync();
    }

    private void SetIvents()
    {
        this.searchVolume.TextChanged += SearchVolume_TextChanged;
        this.checkAll.Click += CheckAll_Click;
        this.volumeList.ItemChecked += VolumeList_ItemChecked;
        this.volumeList.MouseClick += VolumeList_MouseClick;
        this.deleteVolume.Click += DeleteVolume_Click;
        this.refreshVolumeList.Click += RefreshVolumeList_Click;
        this.deleteDockerVolume.Click += DeleteDockerVolume_Click;
        this.copyVolumeName.Click += CopyVolumeName_Click;
    }

    private void VolumeList_MouseClick(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var focusedItem = this.volumeList.FocusedItem;
            if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
            {
                this.volumeContextMenu.Show(Cursor.Position);
            }
        }
    }

    private void VolumeList_ItemChecked(object? sender, ItemCheckedEventArgs e)
    {
        disableActionBtnState();
        if (this.volumeList.CheckedItems.Count == this.volumeList.Items.Count)
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
            this.deleteVolume.Enabled = true;
        }
        else
        {
            this.deleteVolume.Enabled = false;
        }
    }

    private IEnumerable<int> GetSelectedIndexes()
    {
        _selectedVolumes.Clear();

        var indexes = new List<int>();
        foreach (ListViewItem selectedContainer in this.volumeList.CheckedItems)
        {
            if (_volumes.Count > selectedContainer.Index)
            {
                indexes.Add(selectedContainer.Index);
                _selectedVolumes.Add(_volumes[selectedContainer.Index].Name);
            }
        }

        return indexes;
    }

    private void disableActionBtnState()
    {
        this.deleteVolume.Enabled = false;
    }

    private void CheckAll_Click(object? sender, EventArgs e)
    {
        ChangeCheckboxStateForVolumes(this.checkAll.Checked);
    }

    private void ChangeCheckboxStateForVolumes(bool state)
    {
        foreach (ListViewItem item in this.volumeList.Items)
        {
            item.Checked = state;
        }
    }

    private void SearchVolume_TextChanged(object? sender, EventArgs e)
    {
        filter = this.searchVolume.Text;
        RefreshVolumesAsync(false);
    }

    private void RefreshVolumeList_Click(object sender, EventArgs e)
    {
        this.refreshVolumeList.Enabled = false;
        RefreshVolumesAsync();
    }

    private async Task RefreshVolumesAsync(bool getFreshData = true)
    {
        if (getFreshData)
        {
            var getVolumes = new Action<IEnumerable<Volume>>(x =>
            {
                _volumes = x.ToList();
                ViewVolumes();
                this.refreshVolumeList.Enabled = true;
            });
            await volumeService.GetVolumesAsync(new Progress<IEnumerable<Volume>>(getVolumes));
        }
        else
        {
            ViewVolumes();
            this.refreshVolumeList.Enabled = true;
        }
    }

    private IEnumerable<Volume> FilteredList() =>
        filter.Length > 0 ? _volumes.Where(c => c.Name.IndexOf(this.searchVolume.Text) == 0) : _volumes;

    private void ViewVolumes()
    {
        var list = new List<ListViewItem>();

        foreach (var item in FilteredList())
        {
            var lvi = new ListViewItem();
            lvi.Checked = _selectedVolumes.Contains(item.Name);
            lvi.SubItems.Add(item.Name);
            lvi.SubItems.Add(item.Size);
            list.Add(lvi);
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (i < this.volumeList.Items.Count)
            {
                if (!this.volumeList.Items[i].Compare(list[i]))
                {
                    this.volumeList.Items[i] = list[i];
                }
            }
            else
            {
                this.volumeList.Items.Add(list[i]);
            }
        }
        if (list.Count < this.volumeList.Items.Count)
        {
            while (this.volumeList.Items.Count != list.Count)
            {
                this.volumeList.Items.RemoveAt(list.Count);
            }
        }
    }

    private void DeleteVolume_Click(object sender, EventArgs e)
    {
        DeleteVolumes();
    }

    private async Task DeleteVolumes()
    {
        var deleteResult = new Action<string>(x =>
        {
            RefreshVolumesAsync();
        });
        foreach (int index in GetSelectedIndexes())
        {
            await volumeService.DeleteVolumeAsync(new Progress<string>(deleteResult), FilteredList().ToList()[index].Name);
        }
    }

    private void DeleteDockerVolume_Click(object sender, EventArgs e)
    {
        var focusedItem = this.volumeList.FocusedItem;
        var index = focusedItem.Index;
        DeleteVolume(index);
    }

    private async Task DeleteVolume(int index)
    {
        var deleteResult = new Action<string>(x =>
        {
            RefreshVolumesAsync();
        });
        await volumeService.DeleteVolumeAsync(new Progress<string>(deleteResult), FilteredList().ToList()[index].Name);
    }

    private void CopyVolumeName_Click(object sender, EventArgs e)
    {
        var focusedItem = this.volumeList.FocusedItem;
        var index = focusedItem.Index;

        Clipboard.SetText(FilteredList().ToList()[index].Name);
    }
}
