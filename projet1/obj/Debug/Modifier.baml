   M S B A M L   `   `   `  ����B  >projet1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:projet1projet1  5          projet1.Modifier   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:projet1     5      k gTelerik.Windows.Controls.Input, Version=2018.1.220.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2018.1.220.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2018.1.220.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2018.1.220.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a	 ]Telerik.Windows.Data, Version=2018.1.220.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2018.1.220.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
 5      
�������.��5      � -   5          �Name$  gridMain��5       $��27,27,10,29q�6    � 	Resources 5   
   0  *Telerik.Windows.Controls.DataFormDataField �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self	 �� RelativeSource
 �� Path   
MyTemplate � ColumnDefinitions � RowDefinitions   Label   DataMemberBinding �� Mode �� ValidatesOnDataErrors0  *Telerik.Windows.Controls.DataFormDateField��%�  '        &	  �     �� 5      "  6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 64   �� #	 Z $2
 ,(Validation.Errors).CurrentItem.ErrorContent�5      5      �� 5      .R�5      �  5      �� 5      $��* �6+   �� 5      $��0* �6+    5      �� 5      $��5* �6(   �� 5      $��4* �6(   �� 5      $��0* �6(   �� 5      $��0* �6(   �� 5      $��5* �6(   �� 5       $��4* �6(   �� 5!      $��0* �6(   �� 5"      $��0* �6(   �� 5#      $��* �6(   .+�5%        $	��cne��60   $	 Cne��6;   
�������$��16(�6�    6G   �� $	
 cne�$ TwoWay=� . 6�     5&      $	��nom��6=   $��2��60   $	 Nom��6H   
�������$��16(�6�    6T   �� $	
 nom�$ TwoWay=� . 6�     5'      $��prenom��6=   $��3��60   $ Prenom��6K   
�������$��16(�6�    6Z   �� $
 prenom�$ TwoWay=� . 6�     5(      $��adress��6=   $��4��60   $ Address��6K   
�������$��16(�6�    6[   �� $
 adresse�$ TwoWay=� . 6�     5)      $��date_naissance��6>   $��5��60   $ Date de naissance��6T   
�������$��16(�6�    6n   �� $
 
date_naiss�$ TwoWay=�6�     5*      $
��sexe��60   $��6��6<   $
 Sexe��6I   
�������$��16(�6�    6V   �� $

 sexe�$ TwoWay=� . 6�     5+      $��filiere��60   $��8��6?   $ Filière��6L   
�������$��16(�6�    6\   �� $
 Filiere.Nom_filiere�$ TwoWay=� . 6�     5,      $
��tele��6=   $��7��60   $ 	Telephone��6I   
�������$��16(�6�    6[   �� $
 	telephone�$ TwoWay=� . 6�     5-        5.      $��image��6=   $��1��60   $ Image��6J   
�������$��16(�6�    6X   �� $
 image�$ TwoWay=���5/      �� 50      $	��img��6K   $
��Fill=�6$   $��50��63   $��50��6>   ��6V   �� *image+52      53      54      55      .+�56   
   *  $Telerik.Windows.Controls.RadDataForm  -   5        $��radform��56      ���	#FFF7F7F7$
��Left=�6E   $��
112,36,0,0q�6`   $	��Top=�6t   $	��305��6�   $	��536��6�      AutoGenerateFields .     ReadOnlyTemplate# [  57         EditTemplate# [  6�      NewItemTemplate# [  6�      ItemsSource 6@   ��    projet1.ListerFiliers   lister �� Source# Z  �� ValidatesOnExceptions .  �� NotifyOnValidationError . ��58      �� 59       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5:      �  � Color$ 	#FF2A64FF��6#   � 5;      $ 	#FFFFEFEF��6#    � Offset$ 1Q�65   � 5<      $ 	#FF3865E0��6#   � 5=      $ 	#FF699AB6��6#   $ 0.973Q�65   5>      5@      �� 5A   
   -   5         ��Name$ uploadButton��5A      $��Changer Image��6'   $
��Left=�6?   $��27��6Z   $��319,358,0,0q�6f   $	��Top=�6{   $	��145��6�     J� RenderTransformOrigin$  1.296,1.581&�6�   6�   �� 5B   
   -   5        $ 	radButton��5B      $��Valider modification��6$   $
��Left=�6C   $
��Auto��6^   $��110,358,0,0q�6l   $	��Top=�6�   $	��172��6�   $  -0.916,0.307&�6�   6�   �� 5C   
   -   5        ! ��Name$! label��5C      $-��'Fenêtre de modification des étudiants��6   $
��Left=�6O   $��	246,2,0,0q�6j   $	��Top=�6}   $	��298��6�   ���	#DD3022BD$��16(�6�   �� 5D   
   -   5        $! error��5D      $
��Left=�6    $��102,275,0,0q�6;   $	��Top=�6P   $  -0.185,1.613&�6h   $	��246��6�   ���	#FFE81111$��34��6�   ��6�   Z� 6�   �� 5E   
   -   5        $ uploadButton_Copy��5E      $��Retour��6,   $
��Left=�6=   $��27��6X   $��517,358,0,0q�6d   $	��Top=�6y   $	��145��6�   $  1.296,1.581&�6�   6�   5F      5G      