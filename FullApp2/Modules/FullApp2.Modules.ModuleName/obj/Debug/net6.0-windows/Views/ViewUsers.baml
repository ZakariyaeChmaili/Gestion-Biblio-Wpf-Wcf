   M S B A M L   `   `   `  ����  FullApp2.Modules.ModuleName1    +FullApp2.Modules.ModuleName.Views.ViewUsers   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��5q�6   $��0��6*   .��5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5      ��  +  'MaterialDesignFloatingActionLightButton#��[  5      $	��Add��5      $��8q�5      $
��10 0q�6%   ��5      �� *UserFormCommand+.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�6.   5      �� 5       , (MaterialDesignFloatingActionAccentButton#��[ 5      $��8q�5    7   $
��10 0q�6C   ��6   �� *DeleteCommand+.��5!        $ Delete=�6.   5"      �� 5#       * &MaterialDesignFloatingActionDarkButton#��[ 5%      $��Update��5&   9   $��8q�6S   $
��10 0q�6_   ��6   �� *UserFormCommand+.��5'        $	 Pen=�5)      5*      5+      5,        5.   
   $��1��6   $
��0 15q�6+   .��50      ��  �� SelectionMode$ Single=�65   ��6   �� *Users+ �� SelectedItem 6L   �� *SelectedItem+ �� View 51      �� 52      .P�54      ��  �� CellTemplate 55      �� 56   "   .R�57   &   �� $��50��6-   $��70��68   ._�58   *   �� $c��]C:\Users\007\source\repos\FullApp2\FullApp2\FullApp2.Core\Images\Users\ProfilePlaceHolder.jpg��60   59   '   5:   #   5<      �� 5=      $��	FirstName��6)   	 �� Width$		 150��6g   
 �� DisplayMemberBinding
 6<   �� *	FirstName+6g   �� 5>      $��LastName��6)   $		 150��6e   
 6;   �� *
LastName+6e   �� 5?      $��Username��6)   $		 150��6e   
 6;   �� *
Username+6e   �� 5B      $��Password��6)   $		 150��6e   
 6;   �� *
Password+6e   5F      5H      5L      5O      5P      