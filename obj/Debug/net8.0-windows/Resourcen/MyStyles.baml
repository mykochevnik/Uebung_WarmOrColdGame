   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   
dockp_main �� Property �� Value  stackp_main  stackp_history  stackp_toggle  stackp_UserInput 
 l_game  MyGradientBrushRich  MyTextBlockBase  	MainColor 	 MyTextBoxBase 
 tblock_gameRules �� BasedOn  tblock_SearchedNumber  tbox_userInput  tblock_TrialMessage  tblock_SingleMessage �� Triggers �� Binding �� Path �� Value  tblock_SingleTipp  tblock_errorMessage  dockp_historyItem  	lv_trials  lwItemStyle P� Property	 P� Value  list_tb_userValue  list_tb_message  scrollv_Trials  button_gover_window
 �� 
TargetType ��Name  MyGradientBrush �� CornerRadius � 	Resources3   -System.Windows.Media.Effects.DropShadowEffect  Key    Color    
BlurRadius    ShadowDepth    Opacity J� Effect �� ResourceKey �� Triggers �� 
TargetName�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      Cmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      %q  &	        &	 y     &	      &	 l    &	 �    &	 a    7  &	 j    7  &		     7  &	
 t    7  &	 {    7  &	 �    7 	 &	 }    7  &	 �    7  &	 �
    7  &	 �    7  &	 �    &	 �    &	 �    &	 e    7  &	 6    7  &	     &	 �    7  0�� 5�      $ shadowEffect��6-   1�� 5      "  ]�6   .�5   
   ��  � ��$ Center=�60   �� 5   
    � ��$ 30 20 30 20q�6#   5      �� 5
      "  ��6   .�5   
   ��  �@��Orientation$ Vertical=�6(   �� 5   
    � ��$ Center=�60   �� 5   
    � ��$	 400��6%   5      �� 5      "  ��6   .�5   
   ��  � ��$ Center=�60   5      �� 5      "  ��6   .�5   
   ��  � ��$ 10 10q�6#   5      �� 5      "  ��6   .�5   
   ��  � ��$
 auto��6"   �� 5   
    �@��Orientation$ 
Horizontal=�6(   �� 5   
    � ��$ Center=�60   5      �� 5      "  ��6   .�5   
   ��  � ��$ Trebuchet MS)�6'   �� 5    
    � ��$ 36(�6%   �� 5!   
    � ��$ 10 10q�6#   �� 5"   
    � ��$ 10q�6$   �� 5#   
    � ��$ Center=�60   �� 5$   
    � ��8   6'   5%      �� 5'      "  ��6   .�5(   
   ��  � ��$ Trebuchet MS)�6'   �� 5)   
    � ��8   6'   �� 5*   
    � ��$
 Wrap=�6)   5+      �� 5-      "  ��6   .�5.   
   ��  � ��$ Trebuchet MS)�6'   �� 5/   
    � ��8   6'   50      �� 53      "  ��6   8   .�54   
   ��  � ��$ 16(�6%   �� 55   
    �@��Padding$ 10 10 10 20q�6$   �� 56   
    �@��TextAlignment$ Justify=�6*   �� 57   
    � ��$
 Wrap=�6)   �� 58   
    � ��$ Center=�60   59      �� 5;      "  ��6   8   .�5<   
   ��  � ��$ 20(�6%   �� 5=   
    � ��$ 0q�6#   �� 5>   
    �@��Padding$ 0q�6$   �� 5?   
    � ��$	 100��6"   �� 5@   
    �@��TextAlignment$ Center=�6*   �� 5A   
    � ��$ Center=�60   5B      �� 5D      "  ��6   8   .�5E   
   ��  � ��$ 20(�6%   �� 5F   
    � ��$ 0q�6,   �� 5G   
    � ��$ 0q�6#   �� 5H   
    � ��$ 0q�6$   �� 5I   
    �@��TextAlignment$ Center=�6*   �� 5J   
    � ��$	 100��6"   �� 5K   
    � ��$ Center=�60   �� 5L   
    � ��$ Center=�67   �� 5M   
    � ��$ Center=�65   �� 5N   
    � ��
 ���� 6(   �� 5O   
    �@��SelectionBrush
 ���� 6+   5P      �� 5R      "  ��6   8   .�5S   
   ��  � ��$ 16(�6%   �� 5T   
    �@��Padding$ 5q�6$   5U      �� 5X      "  ��6   8   .�5Y   
   ��  � ��$ 16(�6%   �� 5Z   
    �@��TextAlignment$ Center=�6*   �� 5[   
    � ��$
 Wrap=�6)    5\   
   �� 5]       6   �� $ CurrentTrial.IsCloser� True6I   .a�5^      ��  � ��
 �  ��6/   5_      �� 5`       6   �� $ CurrentTrial.IsCloser�	 False6I   .a�5a      ��  � ��
 ��  �6/   5b      5d      �� 5f      "  ��6   8   .�5g   
   ��  � ��$ 16(�6%   �� 5h   
    � ��$ Italic$�6&   �� 5i   
    �@��Padding$ 5q�6$   �� 5j   
    �@��TextAlignment$ Center=�6*   �� 5k   
    � ��$
 Wrap=�6)   5l      �� 5n      "  ��6   8   .�5o   
   ��  � ��$ 12(�6%   �� 5p   
    �@��Padding$ 5q�6$   �� 5q   
    � ��$
 Bold"�6'   �� 5r   
    � ��$ Italic$�6&   �� 5s   
    � ��
 �  ��6'   �� 5t   
    �@��TextAlignment$ Center=�6*   5u      �� 5w      "  ]�6   5x      �� 5z      "  ��6   .�5{   
   ��  � ��$
 auto��6"   �� 5|   
    � ��$
 Left=�60   �� 5}   
    � ��$ 10 10q�6#   �� 5~   
    � ��$ 10 10q�6$   �� 5   
    � ��
 ���� 6(   �� 5�   
    � ��
 �����6'   5�      �� 5�      "  ��6   .�5�   
   ��  � ��
 �����6'    5�   
   P� 5�       �@J�IsMouseOver$
	 True��6-   . �5�      ��  � ��
 �����6/   5�      P� 5�       �@��
IsSelected$
	 True��6,   . �5�      ��  � ��
 �����6/   5�      P� 5�       �@J�	IsFocused$
	 True��6+   . �5�      ��  � ��
 �����6/   5�      5�      �� 5�      "  ��6   8   .�5�   
   ��  � ��$ 12(�6%   �� 5�   
    � ��$ 0 5 10 0q�6#   �� 5�   
    �@��TextAlignment$
 Left=�6*   �� 5�   
    � ��$
 Left=�60   5�      �� 5�      "  ��6   8   .�5�   
   ��  � ��$ 12(�6%   �� 5�   
    �@��TextAlignment$
 Left=�6*   �� 5�   
    � ��$ 10 5 0 0q�6#   �� 5�   
    � ��$
 Wrap=�6)   �� 5�   
    � ��$
 Left=�60    5�   
   �� 5�       6   �� $ IsCloser� True6<   .a�5�      ��  � ��
 �  ��6/   5�      �� 5�       6   �� $ IsCloser�	 False6<   .a�5�      ��  � ��
 ��  �6/   5�      5�      �� 5�      "  ��6   .�5�   
   ��  � ��$
 Auto=�6:   �� 5�   
    � ��$
 Auto=�68   �� 5�   
    � ��$
 True��6-   �� 5�   
    � ��$	 450��6#   5�      �� 5�      "  ��6   .�5�   
   ��  � ��$	 150��6"   �� 5�   
    � ��$ 40��6#   �� 5�   
    � ��$ 10 20 10 10q�6#   �� 5�   
    � ��$ 5q�6$   �� 5�   
    � ��
 �   �6'   �� 5�   
    � ��$ 16(�6%   �� 5�   
    � �� 5�      �� 5�      "
 ��6"   .R�5�      �� $ gover_button_border��6   #��z��5�      8��  $��3q�5�      $ 15��5�       5�      ��   5�      shadowEffect $
 Gray��5�   +   $ 5Q�5�   +   $ 3Q�5�   +   $	 0.5Q�5�   +   5�       5�      2 ._�5�      �� $��Center=�6+   $��Center=�6H   5�       5�      P� 5�       � ��$
	 True��67   . �5�      �� $ gover_button_border��6%    �@J�Effect 5�   "      5�   &   $
 Gray��67   $ 8Q�5�   3   $ 5Q�5�   3   $ 0Q�5�   3   5�      5�      5�      5�      5�      5�      