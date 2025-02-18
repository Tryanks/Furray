using System.Reactive.Disposables;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using DialogHostAvalonia;
using Furray.Desktop.Common;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace Furray.Desktop.Views;

public partial class SubSettingWindow : ReactiveWindow<SubSettingViewModel>
{
    private bool _manualClose;

    public SubSettingWindow()
    {
        InitializeComponent();

        menuClose.Click += menuClose_Click;
        Closing += SubSettingWindow_Closing;
        ViewModel = new SubSettingViewModel(UpdateViewHandler);
        lstSubscription.DoubleTapped += LstSubscription_DoubleTapped;
        lstSubscription.SelectionChanged += LstSubscription_SelectionChanged;

        this.WhenActivated(disposables =>
        {
            this.OneWayBind(ViewModel, vm => vm.SubItems, v => v.lstSubscription.ItemsSource).DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.SelectedSource, v => v.lstSubscription.SelectedItem).DisposeWith(disposables);

            this.BindCommand(ViewModel, vm => vm.SubAddCmd, v => v.menuSubAdd).DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.SubDeleteCmd, v => v.menuSubDelete).DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.SubEditCmd, v => v.menuSubEdit).DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.SubShareCmd, v => v.menuSubShare).DisposeWith(disposables);
        });
    }

    private async Task<bool> UpdateViewHandler(EViewAction action, object? obj)
    {
        switch (action)
        {
            case EViewAction.CloseWindow:
                Close();
                break;

            case EViewAction.ShowYesNo:
                if (await UI.ShowYesNo(this, ResUI.RemoveServer) == ButtonResult.No)
                {
                    return false;
                }

                break;

            case EViewAction.SubEditWindow:
                if (obj is null)
                {
                    return false;
                }

                var window = new SubEditWindow((SubItem)obj);
                await window.ShowDialog(this);
                break;

            case EViewAction.ShareSub:
                if (obj is null)
                {
                    return false;
                }

                await ShareSub((string)obj);
                break;
        }

        return await Task.FromResult(true);
    }

    private async Task ShareSub(string url)
    {
        if (Utils.IsNullOrEmpty(url))
        {
            return;
        }

        var dialog = new QrcodeView(url);
        await DialogHost.Show(dialog, "dialogHostSub");
    }

    private void LstSubscription_DoubleTapped(object? sender, TappedEventArgs e)
    {
        ViewModel?.EditSubAsync(false);
    }

    private void LstSubscription_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        ViewModel.SelectedSources = lstSubscription.SelectedItems.Cast<SubItem>().ToList();
    }

    private void menuClose_Click(object? sender, RoutedEventArgs e)
    {
        _manualClose = true;
        Close(ViewModel?.IsModified);
    }

    private void SubSettingWindow_Closing(object? sender, WindowClosingEventArgs e)
    {
        if (ViewModel?.IsModified == true)
        {
            if (!_manualClose)
            {
                menuClose_Click(null, null);
            }
        }
    }
}
