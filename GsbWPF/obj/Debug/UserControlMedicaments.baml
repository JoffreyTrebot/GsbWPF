   M S B A M L   `   `   `  ����A  =GsbWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GsbWPFGsbWPF  5      #    GsbWPF.UserControlMedicaments   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5       localclr-namespace:GsbWPF  5      -   5        .��5
      � $��Center=�6   $	��Top=�6(   $
��10,0q�6@   .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TransitioningContentSlide��5   /   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6R   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:1X�.��5      � .+�5      ��  �� Orientation$ 
Horizontal=�6   $��17,15,342,0q�66   $��Center=�6K   $	��Top=�6h   .+�5      �� $ 
Horizontal=�6!   $��10q�6:   $��Center=�6F   $	��Top=�6c   .+�5      �� $
��Code��6    $��18(�6/   $��Center=�6=   $	��Top=�6Z   �� 5      -   5         ��Name$ tbx_num��5   @   $	��150��6"   {�.  $��18(�6Q   $��Center=�6_   $	��Top=�6|   5      5      �� 5      $ 
Horizontal=�6   $��275,25,51,0q�66   $��Center=�6K   $	��Top=�6h   .+�5      �� $	��Nom��6   $��18(�6*   $��Center=�68   $	��Top=�6U   �� 5      -   5        $ tbx_Nom��5   <   $	��205��6   {�.  $��18(�6M   $��Center=�6[   $	��Top=�6x   5      �� 5      $ 
Horizontal=�6   $��
3,79,306,0q�66   $��Center=�6J   $	��Top=�6g   .+�5      �� $��Famille��6   $��18(�6.   $��Center=�6<   $	��Top=�6Y   �� 5      -   5        $ tbx_fam��5   <   $	��205��6   {�.  $��18(�6M   $��Center=�6[   $	��Top=�6x   5      �� 5      $ 
Horizontal=�6   $��3,127,125,0q�66   $��Center=�6K   $	��Top=�6h   .+�5      �� $��Composition��6   $��18(�62   $��Center=�6@   $	��Top=�6]   �� 5       -   5        $ 	tbx_compo��5       {�.  $��18(�6C   $	��340��6R   $��Center=�6^   $	��Top=�6{   5!      �� 5#      $ 
Horizontal=�6   $��	2,176,6,0q�66   $��Center=�6I   $	��Top=�6f   .+�5$      �� $��Effets indérisables��6   $��18(�6:   $��Center=�6H   $	��Top=�6e   �� 5%      -   5        $ 	tbx_effet��5%       �� 
IsReadOnly . $��18(�6D   $	��420��6R   $��Center=�6^   $	��Top=�6{    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6�   $��86��6�   5&      �� 5(      $ 
Horizontal=�6   $��-1,275,24,0q�66   $��Center=�6K   $	��Top=�6h   .+�5)      �� $��Contre indications��6   $��18(�69   $��Center=�6G   $	��Top=�6d   �� 5*      -   5        $ 	tbx_indic��5*       . $��18(�6D   $	��402��6R   $��Center=�6^   $	��Top=�6{   $
 Wrap=�6�    . $
 Auto=�6�   $	��106��6�   5+      �� 5-      $ 
Horizontal=�6   $��
295,91,4,0q�66   $��Center=�6J   $	��Top=�6g   .+�5.      �� $��Prix Echantillon��6   $��18(�67   $��Center=�6E   $	��Top=�6b   �� 5/      -	   5        $ tbx_prix��5/      {�.  $��18(�6D   $	��150��6R   $��Center=�6^   $	��Top=�6{   50      �� 51      -
   5        	 ��Name$	 btn_prec��51      $��	PRECEDENT��6+   $
��Left=�6?   
����iA�$��
92,406,0,0q�6�   $	��Top=�6�   $	��193��6�   $��74��6�   $��18(�6�   ��6q   Z� 6�   �� 52      -   5        $	 btn_suiv��52      $��SUIVANT��6+   $
��Left=�6=   
����iA�$��316,406,0,0q�6�   $	��Top=�6�   $	��193��6�   $��74��6�   $��18(�6�   ��6o   Z� 6�   53      54      55      56      