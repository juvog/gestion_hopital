   M S B A M L   `   `   `  ����>  :nlh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:nlhnlh  5   	       nlh.admin_admissions   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:nlh     5   	   -   5          � Title$  
ADMISSIONS��5   	   $	��450��6   $
��1119��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��320* �6   �� 5      $
��791* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dtgAdmissions��5         
IsReadOnly . $
��Left=�6<   $	��325��6W   $	��Top=�6d   $
��1055��6|   $��	20,35,0,0q�6�      AutoGenerateColumns .  $��2��6�   ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id Admission��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *idAdmission+  5      $	 nss��6%    62   �� *nss+  5      $ Prénom��6%    65   �� *prenom+  5      $	 Nom��6%    62   �� *nom+  5      $ date Admission��6%    6=   �� *dateAdmission+  5      $ No Lit��6%    65   �� *noLit+  5      $ 	Chirurgie��6%    68   �� *chirurgieProg+  5      $ Date Chirurgie��6%    6=   �� *dateChirurgie+  5      $ Téléviseur��6%    69   �� *
televiseur+  5      $ Téléphone��6%    68   �� *	telephone+  5      $ Date congé��6%    69   �� *	dateConge+5      �� 5   
   -   5         ��Name$ 
btnQuitter��5      $��Quitter��6%   $
��Left=�67   $��680,375,0,0q�6R   $	��Top=�6g   $��75��6   $��1��6�   5      5      