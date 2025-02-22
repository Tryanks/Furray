﻿using Avalonia.Controls;

namespace Furray.Desktop.Views;

public partial class GlobalHotkeySettingWindow : Window
{
    private static Config _config = default!;
    private Dictionary<object, KeyEventItem> _TextBoxKeyEventItem = default!;

    public GlobalHotkeySettingWindow()
    {
        InitializeComponent();

        btnCancel.Click += (s, e) => Close();
        _config = AppHandler.Instance.Config;
        //_config.globalHotkeys ??= new List<KeyEventItem>();

        //txtGlobalHotkey0.KeyDown += TxtGlobalHotkey_PreviewKeyDown;
        //txtGlobalHotkey1.KeyDown += TxtGlobalHotkey_PreviewKeyDown;
        //txtGlobalHotkey2.KeyDown += TxtGlobalHotkey_PreviewKeyDown;
        //txtGlobalHotkey3.KeyDown += TxtGlobalHotkey_PreviewKeyDown;
        //txtGlobalHotkey4.KeyDown += TxtGlobalHotkey_PreviewKeyDown;

        //HotkeyHandler.Instance.IsPause = true;
        //this.Closing += (s, e) => HotkeyHandler.Instance.IsPause = false;
        //InitData();
    }

    //private void InitData()
    //{
    //    _TextBoxKeyEventItem = new()
    //    {
    //        { txtGlobalHotkey0,GetKeyEventItemByEGlobalHotkey(_config.globalHotkeys,EGlobalHotkey.ShowForm) },
    //        { txtGlobalHotkey1,GetKeyEventItemByEGlobalHotkey(_config.globalHotkeys,EGlobalHotkey.SystemProxyClear) },
    //        { txtGlobalHotkey2,GetKeyEventItemByEGlobalHotkey(_config.globalHotkeys,EGlobalHotkey.SystemProxySet) },
    //        { txtGlobalHotkey3,GetKeyEventItemByEGlobalHotkey(_config.globalHotkeys,EGlobalHotkey.SystemProxyUnchanged)},
    //        { txtGlobalHotkey4,GetKeyEventItemByEGlobalHotkey(_config.globalHotkeys,EGlobalHotkey.SystemProxyPac)}
    //    };
    //    BindingData();
    //}

    //private void TxtGlobalHotkey_PreviewKeyDown(object? sender, KeyEventArgs e)
    //{
    //    e.Handled = true;
    //    var _ModifierKeys = new Key[] { Key.LeftCtrl, Key.RightCtrl, Key.LeftShift,
    //        Key.RightShift, Key.LeftAlt, Key.RightAlt, Key.LWin, Key.RWin};
    //    _TextBoxKeyEventItem[sender].KeyCode = (int)(e.Key == Key.System ? (_ModifierKeys.Contains(e.SystemKey) ? Key.None : e.SystemKey) : (_ModifierKeys.Contains(e.Key) ? Key.None : e.Key));
    //    _TextBoxKeyEventItem[sender].Alt = (Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt;
    //    _TextBoxKeyEventItem[sender].Control = (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control;
    //    _TextBoxKeyEventItem[sender].Shift = (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;
    //    (sender as TextBox)!.Text = KeyEventItemToString(_TextBoxKeyEventItem[sender]);
    //}

    //private KeyEventItem GetKeyEventItemByEGlobalHotkey(List<KeyEventItem> KEList, EGlobalHotkey eg)
    //{
    //    return JsonUtils.DeepCopy(KEList.Find((it) => it.eGlobalHotkey == eg) ?? new()
    //    {
    //        eGlobalHotkey = eg,
    //        Control = false,
    //        Alt = false,
    //        Shift = false,
    //        KeyCode = null
    //    });
    //}

    //private string KeyEventItemToString(KeyEventItem item)
    //{
    //    var res = new StringBuilder();

    //    if (item.Control) res.Append($"{ModifierKeys.Control}+");
    //    if (item.Shift) res.Append($"{ModifierKeys.Shift}+");
    //    if (item.Alt) res.Append($"{ModifierKeys.Alt}+");
    //    if (item.KeyCode != null && (Key)item.KeyCode != Key.None)
    //        res.Append($"{(Key)item.KeyCode}");

    //    return res.ToString();
    //}

    //private void BindingData()
    //{
    //    foreach (var item in _TextBoxKeyEventItem)
    //    {
    //        if (item.Value.KeyCode != null && (Key)item.Value.KeyCode != Key.None)
    //        {
    //            (item.Key as TextBox)!.Text = KeyEventItemToString(item.Value);
    //        }
    //        else
    //        {
    //            (item.Key as TextBox)!.Text = string.Empty;
    //        }
    //    }
    //}

    //private void btnSave_Click(object? sender, RoutedEventArgs e)
    //{
    //    _config.globalHotkeys = _TextBoxKeyEventItem.Values.ToList();

    //    if (ConfigHandler.SaveConfig(_config, false) == 0)
    //    {
    //        HotkeyHandler.Instance.ReLoad();
    //        this.Close();
    //    }
    //    else
    //    {
    //        UI.Show(ResUI.OperationFailed);
    //    }
    //}

    //private void btnReset_Click(object? sender, RoutedEventArgs e)
    //{
    //    foreach (var k in _TextBoxKeyEventItem.Keys)
    //    {
    //        _TextBoxKeyEventItem[k].Alt = false;
    //        _TextBoxKeyEventItem[k].Control = false;
    //        _TextBoxKeyEventItem[k].Shift = false;
    //        _TextBoxKeyEventItem[k].KeyCode = (int)Key.None;
    //    }
    //    BindingData();
    //}

    //private void GlobalHotkeySettingWindow_KeyDown(object? sender, KeyEventArgs e)
    //{
    //    if (e.Key == Key.Escape)
    //    {
    //        this.Close();
    //    }
    //}
}
