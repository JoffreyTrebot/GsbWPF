   M S B A M L   `   `   `  ����A  =GsbWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GsbWPFGsbWPF  5   	       GsbWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	    localclr-namespace:GsbWPF  5   	     � Title$  
MainWindow��5	   	   $	��600��6   $
��1024��6)    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[    � WindowStyle$
 None=�6q   .��5
      � -   5        .+�5   
   �� .+�5      � 
����iA�$��50��6*   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $��10q�6R   .+�5      �� -   5        $��30��5      $��30��6(   $��0q�64   ��6@   Z� ��6V   Z� .��5      �� $��Assets/error.png��6    5      5      5      5      � 5   
   $��
250 55 0 0q�6   .+�5      � -   5         �Name$ GridPrincipal��5      $��Center=�6*   $	��Top=�6G   5      � 5   
   $	��250��6   $
��Left=�6   ���	#FF222222.+�5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TransitioningContentSlide��5   3   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6V   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.2X�.��5      � -   5        $ 
GridCursor��5      $��	0 100 0 0q�6+   $	��Top=�6>   
����iA�$��10��6m   $
��Left=�6x   $��60��6�   5      �� 5      -   5        	 ��Name$	 ListViewMenu��5      $��0,100,0,100q�6-   
����������	#FF222222$��Center=�6p   $	��250��6�   ��6�   Z� .@�5      �� $��60��6   .��5      �� $ 
Horizontal=�6!   .+�5       �� $��30��6    $��30��6+   $��Center=�67   $��5q�6R   $��Assets/006-shapes.png��6]   6~   �� 5!      $��Nouveau Rapport��6$   $��20(�6;   $��Center=�6I   $
��10 0q�6d   $��Verdona Pro)�6r   $��DemiBold"�6�   5"      5#      �� 5$      $��60��6   .��5%      �� $ 
Horizontal=�6!   .+�5&      �� $��30��6    $��30��6+   $��Center=�67   $��5q�6R   $'��!Assets/005-consulting-message.png��6]   6�   �� 5'      $��Consulter Rapport��6$   $��20(�6=   $��Center=�6K   $
��10 0q�6f   $��Verdona Pro)�6t   $��DemiBold"�6�   5(      5)      �� 5*      $��60��6   .��5+      �� $ 
Horizontal=�6!   .+�5,      �� $��30��6    $��30��6+   $��Center=�67   $��5q�6R   $��Assets/002-doctor.png��6]   6~   �� 5-      $��
Praticiens��6$   $��20(�66   $��Center=�6D   $
��10 0q�6_   $��Verdona Pro)�6m   $��DemiBold"�6�   5.      5/      �� 50      $��60��6   .��51      �� $ 
Horizontal=�6!   .+�52      �� $��30��6    $��30��6+   $��Center=�67   $��5q�6R   $��Assets/004-pills.png��6]   6}   �� 53      $��Médicaments��6$   $��20(�67   $��Center=�6E   $
��10 0q�6`   $��Verdona Pro)�6n   $��DemiBold"�6�   54      55      �� 56      $��60��6   .��57      �� $ 
Horizontal=�6!   .+�58      �� $��30��6    $��30��6+   $��Center=�67   $��5q�6R   $��Assets/003-users.png��6]   6}   �� 59      $��	Visiteurs��6$   $��20(�65   $��Center=�6C   $
��10 0q�6^   $��Verdona Pro)�6l   $��DemiBold"�6�   5:      5;      �� 5<      $��60��6   ���#1a1a1a.��5=      �� $ 
Horizontal=�6!   .+�5>      �� $��30��6    $��30��6+   $��Center=�67   $��5q�6R   $-��'Assets/001-stop-or-prohibition-sign.png��6]   6�   �� 5?      $��Déconnexion��6$   $��20(�67   $��Center=�6E   $
��10 0q�6`   $��Verdona Pro)�6n   $��DemiBold"�6�   5@      5A      5B      5C      �� 5D   
   $
��Left=�6   $��82��6+   $��	73,10,0,0q�67   $	��Top=�6J   $	��116��6b   $��Assets/gsblogo.png��6n   �� 5E   
   $��by Trébot Joffrey��6   
�������$
��Left=�6?   $��28��6Z   $��
73,562,0,0q�6f   $	��Top=�6z   5G      5H      