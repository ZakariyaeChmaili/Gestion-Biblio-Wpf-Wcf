   M S B A M L   `   `   `  ����  FullApp2.Modules.ModuleName8    2FullApp2.Modules.ModuleName.Views.ViewReservations   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��5q�5      $��0��5      .��5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5      ��  ,  (MaterialDesignFloatingActionAccentButton#��[  5      $��8q�5   7   $
��10 0q�6C   ��6   �� *DeleteCommand+.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Delete=�6.   5      �� 5       * &MaterialDesignFloatingActionDarkButton#��[ 5       $��Update��5!   @   $��8q�6Z   $
��10 0q�6f   ��6   �� *ReservationFormCommand+.��5"        $	 Pen=�5$      5%      5&      5(        5)   
   $��1��6   $
��0 15q�6+   .��5*      ��  �� SelectionMode$ Single=�6<   ��6   �� *Reservations+ �� SelectedItem 6S   �� *SelectedItem+ �� View 5+      �� 5,      .P�5-      �� $��
Book Title��6)    �� Width$	 150��6i   	 �� DisplayMemberBinding	 6=   �� *
Book.Title+6i   �� 5.      $��Username��6)   $	 150��6j   	 6;   �� *User.Username+6j   �� 50      $��BookId��6)   $	 150��6]   	 69   �� *Id+6]   �� 51      $��UserId��6)   $	 150��6a   	 69   �� *UserId+6a   �� 52      $��	StartDate��6)   $	 150��6g   	 6<   �� *	StartDate+6g   �� 53      $��EndDate��6)   $	 150��6c   	 6:   �� *	EndDate+6c   �� 54      
 �� CellTemplate
 55      �� 56   "   .R�57   &   �� $
��View��6-   ��58   -   �� *$"DataContext.ViewReservationCommand+ �� RelativeSource ��  �� AncestorType UserControl��59   -   �� 5;   #   5=      5>      5@      5A      5B      5D      