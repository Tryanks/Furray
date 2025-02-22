using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using Furray.Desktop.ViewModels;
using ReactiveUI;

namespace Furray.Desktop.Views;

/// <summary>
///     ThemeSettingView.xaml
/// </summary>
public partial class ThemeSettingView : ReactiveUserControl<ThemeSettingViewModel>
{
    public ThemeSettingView()
    {
        InitializeComponent();
        ViewModel = new ThemeSettingViewModel();

        foreach (ETheme it in Enum.GetValues(typeof(ETheme)))
        {
            cmbCurrentTheme.Items.Add(it.ToString());
        }

        for (var i = Global.MinFontSize; i <= Global.MinFontSize + 10; i++)
        {
            cmbCurrentFontSize.Items.Add(i);
        }

        Global.Languages.ForEach(it =>
        {
            cmbCurrentLanguage.Items.Add(it);
        });

        this.WhenActivated(disposables =>
        {
            this.Bind(ViewModel, vm => vm.CurrentTheme, v => v.cmbCurrentTheme.SelectedValue).DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.CurrentFontSize, v => v.cmbCurrentFontSize.SelectedValue)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.CurrentLanguage, v => v.cmbCurrentLanguage.SelectedValue)
                .DisposeWith(disposables);
        });
    }
}
