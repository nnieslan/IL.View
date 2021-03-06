﻿/*
 * The MIT License
 * 
 * Copyright © 2011, Denys Vuika
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 * */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using IL.View.Model;

namespace IL.View.Views
{
  public partial class Settings : Page
  {
    private RepositorySettings _repositorySettings;

    public Settings()
    {
      InitializeComponent();
      _repositorySettings = Resources["RepositorySettings"] as RepositorySettings;
    }

    // Executes when the user navigates to this page.
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    }

    private void OnAddRepositoryClick(object sender, RoutedEventArgs e)
    {
      string address = RepositoryAddress.Text;
      if (string.IsNullOrWhiteSpace(address)) return;

      if (_repositorySettings.AddRepository(address))
        RepositoryAddress.Text = string.Empty;
    }

    private void OnRemoveEntryClick(object sender, RoutedEventArgs e)
    {
      var menuItem = sender as MenuItem;
      if (menuItem == null) return;

      var definition = menuItem.DataContext as RepositoryDefinition;
      if (definition == null) return;

      _repositorySettings.Definitions.Remove(definition);
    }

  }
}
