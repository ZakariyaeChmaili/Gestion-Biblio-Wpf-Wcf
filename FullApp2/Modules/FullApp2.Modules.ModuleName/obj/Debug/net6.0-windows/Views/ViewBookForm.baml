   M S B A M L   `   `   `  ����  FullApp2.Modules.ModuleName4    .FullApp2.Modules.ModuleName.Views.ViewBookForm   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  $   MaterialDesignHeadline5TextBlock#��[  5      $��Center=�5      $��Center=�6*   $��0��6E   $��Book Information��6R   $��30(�6j   #  MaterialDesignThemes.Wpf.Card  5   
   $	��400��6   $��Center=�6.   $��1��6K   $��20q�6X   $��20q�6d   .��5      �  5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� $��0��6   $
��0 20q�6*    �� Orientation$ 
Horizontal=�69   .+�5      �� $��Title:��6   �� 5       $
��20 0q�6    �� TextWrapping$
 Wrap=�6,   $	��130��6\   ��6@   �� *
Book.Title+6\   5!      �� 5$      $��1��6   $
��0 20q�6*   $ 
Horizontal=�68   .+�5%      �� $��Author:��6   �� 5&      $
��20 0q�6   $
 Wrap=�6,   $	��130��6]   ��6@   �� *Book.Author+6]   5'      �� 5*      $��2��6   $
��0 20q�6*   $ 
Horizontal=�68   .+�5+      �� $��Copies:��6   �� 5,      $
��20 0q�6   $
 Wrap=�6,   $	��130��6]   ��6@   �� *Book.Copies+6]   5-      �� 50      $��3��6   $
��0 20q�6*   $ 
Horizontal=�68   .+�51      �� $
��10 0q�6   $��5q�6+   $
��Save��67   ��6F   �� *SaveCommand+��6f   �� *
SaveType+�� 52      $
��10 0q�6   $��5q�6+   $��Cancel��67   ��6H   �� *CancelCommand+53      54      55      56      57      