   M S B A M L   `   `   `  ����  FullApp2.Modules.ModuleName4    .FullApp2.Modules.ModuleName.Views.ViewUserForm   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5      #  MaterialDesignThemes.Wpf.Card  $	��500��5	   	   $��Center=�5   	   $��20q�5   	   $��20q�5   	   .��5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      ��  $   MaterialDesignHeadline5TextBlock#��[  6   $��Center=�5      $��Center=�65   $��0��6P   $��User Information��6]   $��30(�6u   �� 5      $��1��6   $
��0 20q�6&    �� Orientation$ 
Horizontal=�64   .+�5      �� $��	UserName:��6   �� 5       $
��20 0q�6    �� TextWrapping$
 Wrap=�6(   $	��200��6[   ��6<   �� *User.Username+6[   5!      �� 5$      $��2��6   $
��0 20q�6&   $ 
Horizontal=�64   .+�5%      �� $��	Password:��6   �� 5&      $
��20 0q�6   $
 Wrap=�6(   $	��200��6[   ��6<   �� *User.Password+6[   5'      �� 5*      $��3��6   $
��0 20q�6&   $ 
Horizontal=�64   .+�5+      �� $��
FirstName:��6   �� 5,      $
��20 0q�6   $
 Wrap=�6(   $	��200��6\   ��6<   �� *User.FirstName+6\   5-      �� 50      $��4��6   $
��0 20q�6&   $ 
Horizontal=�64   .+�51      �� $��	LastName:��6   �� 52      $
��20 0q�6   $
 Wrap=�6(   $	��200��6[   ��6<   �� *User.LastName+6[   53      �� 56      $��5��6   $
��0 20q�6&   $ 
Horizontal=�64   .+�57      �� $
��10 0q�6   $��8q�6'   $
��Save��63   ��6B   �� *SaveCommand+��6b   �� *
SaveType+�� 58      $
��10 0q�6   $��8q�6'   $��Cancel��63   ��6D   �� *CancelCommand+59      5:      5;      5<      