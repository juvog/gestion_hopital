   M S B A M L   `   `   `  ����>  :nlh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:nlhnlh  5   	       nlh.admin_ajoutSupp   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:nlh     5   	     � Title$$  AJOUTER ET SUPPRIMER MÉDECINS��5   	   $	��422��6/   $	��784��6<   .��5	      � .+�5
   
   �� $��Nom :��6   $
��Left=�6    $��	57,75,0,0q�6;   $	��Top=�6N   $��85��6f   �� 5   
   -   5         ��Name$ txtNom��5      $
��Left=�6"   $��23��6=   $��
157,75,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��120��6�   �� 5   
   -   5         ��Name$ btnRechercher��5      $��
Rechercher��6(   $
��Left=�6=   $��180,203,0,0q�6X   $	��Top=�6m   $��75��6�   6�   �� 5   
   -   5        $ btnSupprimer��5      $��	Supprimer��6'   $
��Left=�6;   $��400,203,0,0q�6V   $	��Top=�6k   $��75��6�   6�   �� 5   
   -   5        $ 
btnAjouter��5      $��Ajouter��6%   $
��Left=�67   $��
57,203,0,0q�6R   $	��Top=�6f   $��75��6~   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtgMedecins��5      $
��Left=�6(   $	��135��6C   $��
350,40,0,0q�6P   $	��Top=�6d   $	��215��6|      
IsReadOnly .    AutoGenerateColumns .  ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id Médecin��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� *	idMedecin+  5      $ Prénom��6%   	 65   �� *prenomMedecin+  5      $	 Nom��6%   	 62   �� *
nomMedecin+5      �� 5   
   -   5        $ txtAide��5      $
��Left=�6#   $	��135��6>   $��
595,40,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��150��6�   �� 5   
   $��	Prénom :��6   $
��Left=�6#   $��
57,117,0,0q�6>   $	��Top=�6R   $��85��6j   �� 5   
   -   5        $ 	txtPrenom��5      $
��Left=�6%   $��23��6@   $��157,117,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5   
   -   5        $ 
btnQuitter��5      $��Quitter��6%   $
��Left=�67   $��680,361,0,0q�6R   $	��Top=�6g   $��75��6   6�   5      5      