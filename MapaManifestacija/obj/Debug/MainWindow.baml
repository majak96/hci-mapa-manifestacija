   M S B A M L   `   `   `  ����L  HMapaManifestacija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MapaManifestacijaMapaManifestacija  5   	   A%clr-namespace:MapaManifestacija.ModelMapaManifestacija.Model  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   A%clr-namespace:MapaManifestacija.ModelMapaManifestacija.Model  5	   	   ?$clr-namespace:MapaManifestacija.HelpMapaManifestacija.Help  5   	   "    MapaManifestacija.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MapaManifestacija     5   	   8local1%clr-namespace:MapaManifestacija.Model     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   6self%clr-namespace:MapaManifestacija.Model     5	   	   2l$clr-namespace:MapaManifestacija.Help     5   	     �Language$  Lt-sr-SP�5   a    � Title$# Mapa manifestacija - Novi Sad��6	    � 
ResizeMode$ CanMinimize=�6/   $	��620��6H   $	��878��6U    � Icon$w qC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\map_icon_Bjj_icon.ico��6a    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5      ]� .+�5   
   ]� $
��Left=�6   $	��190��6*   .+�5      ]� $	��Top=�6   .+�5      �� $	��Top=�6   $��1q�60   $��Pregled podataka��6D   $��SemiBold"�6^   $��3 3 3 3q�6t   $��1q�6�   
�������.��5      R� -   5        $��stablo��5   �   $��	0 20 0 10q�6�   $	��265��6�   $��Normal"�6�    � 	Resources 5       �� DataType.   (MapaManifestacija.Model.TipManifestacije �� ItemsSource	 �� Path
 �� Mode �� Orientation+   %MapaManifestacija.Model.Manifestacija � ToolTip � ColumnDefinitions � RowDefinitions �� StringFormat K� IsItemsHost � Orientation��%z  (��       5   7   *, +)(�� (    5!   +   *, +)�� 5      "  67    6a   �� $	 ListaManifestacija�$
 TwoWay=�.R�5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $��20��6,   $��20��68   $��0 0 5 0q�6p   ��6C   �� $	 Ikonica�$
 TwoWay=�6p   �� 5   &   ��60   �� $	 Naziv�$
 TwoWay=�5   #   5       �� 5!      "  6+   .R�5"   "   �� $ 
Horizontal=�6-   .+�5#   &   �� $��20��6,   $��20��68   $��0 0 5 0q�6o   ��6C   �� $	 Ikonica�$
 TwoWay=�6o   �� 5$   &   ��60   �� $	 Naziv�$
 TwoWay=� 5%   &   � 5&   *    5'   .   �� 5(   2   �� 5)   2    5+   .   �� 5,   2   �� 5-   2   �� 5.   2   �� 5/   2   �� 50   2   .+�52   .   �� $��0��68   $��0��6E   	Oznaka:6^   �� 53   .   $��0��68   $��1��6E   ��6U   �� *Oznaka+6o   �� 54   .   $��1��68   $��0��6E   Datum održavanja:6h   �� 55   .   $��1��68   $��1��6E   ��6U   �� *DatumOdrzavanja+$ {0:dd.MM.yyyy}��6�   �� 56   .   $��2��68   $��0��6E   
Etikete:6_   �� 57   .   $��0 3 0 0q�6;   
������ 
������ $��1��6   $��2��6�   $
��Left=�6�   ��6�   �� $	 ListaEtiketa���58   2   �� 59   6   .R�5:   :   �� $��10��6D   $��2 0 0 0q�6O   $��10��6`   ��6l   �� *Boja+5;   7   ��5=   2   �� 5>   6   .R�5?   :   �  . $ 
Horizontal=�6W   5@   7   5B   /   �� 5C   .   $��2��65   $��3��6I   
�������$��0,1,0,0q�6k   $��0 3 0 0q�6�   �� 5D   .   $��0 3 0 0q�68   $��2��6I   $��4��6]   <:Detaljnije informacije možete naći u tabelarnom prikazu.6�   5E   +   5G   #   5H      5Q      ��5R      �� 5S       �� 
TargetType" Q�6$   .�5T   "   ��  �� Property �@Q�
IsExpanded �� Value . 6?   5U      5W      5X      �� 5Y      $��0 0 0 5q�6   $��Bottom=�6.   $��Center=�6F   $ 
Horizontal=�6c   .+�5Z      �� $��0 0 0 0q�6   $��40��6-   $��40��69   $p��jC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\question64.png��6D    5[      �� 5\      WUDodavanje manifestacije na mapu je moguće prevlačenjem njene ikonice na mapu. Jedna�� 5]   u   XVmanifestacije se samo jednom može dodati na mapu. Prevlačenjem manifestacije koja se�� 5^   v   XVveć nalazi na mapi se menja njena pozicija na mapi. Manifestacije na mapi se ne smeju�� 5_   w   VTpreklapati. Brisanje manifestacije sa mape je moguće prevlačenjem njene ikonice do�� 5`   t   75ikonice ispod stabla koja označava kantu za otpatke.5b      5d      �� 5e      -   5        $��35 0 0 0q�5e       J� 	AllowDrop . $��40��6�   $��40��6�   $i��cC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\can.png��6�   $Q KBrisanje manifestacije sa mape je moguće prevlačenjem njene ikonice ovde.��6
  5f      5g      �� 5j      $��Bottom=�6   $��1q�6-    �� CornerRadius$ 4��6B   $��3 0 3 3q�6S    �� Padding$ 1q�6d   
�������._�5k      �� .+�5l      �� -   5        $��PrikazButton��5l   s   )   #MapaManifestacija.Help.HelpProvider   HelpKey$ index.html#dugmici��6   $��SemiBold"�6I   $��
20 2 20 10q�6_   $+ %Tabelarni prikaz unetih manifestacija��6�   ��5m      �� 5n      $ 
Horizontal=�6)   .+�5o   "   �� -   5        $��PrikazButtonTxt��5o   ,   $��Tabelarni prikaz��6C   $��0 0 0 0q�6[   5q      5s      �� 5t      -   5        $ index.html#unosMan��5t      $��SemiBold"�6J   $��
20 0 20 10q�6`   $@ :Unos potrebnih podataka za manifestaciju i njeno dodavanje��6�   ��5u      �� 5v      $ 
Horizontal=�6)   .+�5w   "   �� $��Dodaj manifestaciju��6,   $��0 0 0 0q�6G   5y      5{      �� 5|      -   5        $ index.html#unosTip��5|      $��SemiBold"�6I   $��
20 0 20 10q�6_   $F @Unos potrebnih podataka za tip manifestacije i njegovo dodavanje��6�   ��5}      �� 5~      $ 
Horizontal=�6)   .+�5   "   �� $��Dodaj tip manifestacije��6,   $��0 0 0 0q�6K   5�      5�      �� 5�      -   5        $ index.html#unosEt��5�      $��SemiBold"�6I   $��
20 0 20 10q�6_   $: 4Unos potrebnih podataka za etiketu i njeno dodavanje��6�   ��5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Dodaj etiketu��6,   $��0 0 0 0q�6A   5�      5�      �� 5�      -	   5        $ index.html#izmena��5�      $��SemiBold"�6I   $��
20 0 20 10q�6_   $ Izmena označene stavke��6�   ��5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Izmeni��6,   $��0 0 0 0q�6:   5�      5�      �� 5�      -
   5        $ index.html#brisanje��5�      $��SemiBold"�6J   $��
20 0 20 10q�6`   $ Brisanje označene stavke��6�   ��5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Obriši��6,   $��0 0 0 0q�6:   5�      5�      �� 5�      -   5        $ index.html#ucitavanje��5�      $��SemiBold"�6L   $��
20 0 20 10q�6b   $ Učitavanje iz datoteke��6�   ��5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Učitaj podatke��6,   $��0 0 0 0q�6B   5�      5�      �� 5�      -   5        $ index.html#cuvanje��5�      $��SemiBold"�6I   $��	20 0 20 2q�6_   $ Čuvanje u datoteku��6�   ��5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Sačuvaj podatke��6,   $��0 0 0 0q�6C   5�      5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ borderSlika��5�   &   $y�Visible=�6   $ 3q�6;   $��Right=�6G   $��1q�6^   $��0,12,5,5q�6r   $ 2��6�   
�������$	��667��6�   ._�5�      �� -   5         ��Name$
 Mapa��5�   +   $y�Visible=�6    �� SelectionMode$ Single=�69    . $��0,0,-1,0q�6W  ��6P   �� $	 ManifestacijeNaMapi���5�      �� 5�       �� 
TargetType" ��6&   .R�5�      �� $��CanvasPanel��6!    . ��5�      �� 5�   "    �� ImageSource$o iC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\moja_mapa.png��6-   5�      5�      ��5�      �� 5�      " ��6   .�5�      ��  �@��Left 68   �� *	Tacka.X+6T   �� 5�       �@��Top 67   �� *	Tacka.Y+6S   5�      ��5�      �� 5�      .R�5�      ��  .  $��43��67   $��43��6B   $
��Left=�6N   $ 
Horizontal=�6i   .+�5�      � .+�5�   "   �� $��30��6(   $��30��63   $��5 5 5 5q�6?   $��Center=�6k   ��6P   �� *	Ikonica+ 5�   &   � 5�   *    5�   .   �� 5�   2   �� 5�   2    5�   .   �� 5�   2   �� 5�   2   �� 5�   2   �� 5�   2   �� 5�   2   �� 5�   2   .+�5�   .   �� $��0��68   $��0��6E   	Oznaka:6^   �� 5�   .   $��0��68   $��1��6E   ��6U   �� *Oznaka+6o   �� 5�   .   $��1��68   $��0��6E   Naziv:6]   �� 5�   .   $��1��68   $��1��6E   ��6U   �� *Naziv+6n   �� 5�   .   $��2��68   $��0��6E   Datum održavanja:6h   �� 5�   .   $��2��68   $��1��6E   ��6U   �� *DatumOdrzavanja+$ {0:dd.MM.yyyy}��6�   �� 5�   .   $��3��68   $��0��6E   
Etikete:6_   �� 5�   .   $��0 3 0 0q�6;   
������ 
������ $��1��6   $��3��6�   $
��Left=�6�   ��6�   �� $	 ListaEtiketa���5�   2   �� 5�   6   .R�5�   :   �� $��10��6D   $��2 0 0 0q�6O   $��10��6`   ��6l   �� *Boja+5�   7   ��5�   2   �� 5�   6   .R�5�   :   �  . $ 
Horizontal=�6W   5�   7   5�   /   �� 5�   .   $��2��65   $��4��6I   
�������$��0,1,0,0q�6k   $��0 3 0 0q�6�   �� 5�   .   $��0 3 0 0q�68   $��2��6I   $��5��6]   <:Detaljnije informacije možete naći u tabelarnom prikazu.6�   5�   +   5�   #   �� 5�   "   $��18��6(   $��18��63   $i��cC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\pin.png��6?   $	��Top=�6�   $��Right=�6�   5�      5�      5�      5�      5�      �� 5�   
   -   5        $ borderTabela��5�      $ 3q�6'   $��1q�63   $��0,12,5,5q�6G   $ 2��6Y   
�������$	��667��6�   ._�5�      � -   5         �Name$ taboviTabela��5�      .+�5�      �� -   5         ��Name$ tabovi��5�      .@�5�      �� $��Manifestacije��6   .��5�      � -   5        $ tabelaPanel��5�       5�      �� 5   "    5     �� 5  "   $��30 �60   �� 5  "   �� 5  "   .+�5	     �� $ 
Horizontal=�6)   $��0��6B   $��0��6O   .+�5
  "   �� $��	200 5 0 0q�6(   $	��Top=�6;   $��20��6S   $��20��6^   $n��hC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\question.png��6j    5  &   �� 5  *   JHUnesite pojam po kom želite da pretražite prikazanu tabelu. Moguće je�� 6z   IGpretraživanje po oznaci, nazivu, tipu, opisu, datumu, kategoriji cena,�� 5  {   IGstatusu alkohola i mestu održavanja. Pretražuje se pritiskom na dugme�� 5  z   DB"Pretraži". Pritiskom na dugme "Poništi" se poništava pretraga.5  +   5  #   �� 5  "   -   5        $��searchManifestacijeTxt��5  U   $ index.html#tabMan��6*   $��20��6t   $��	10 0 15 0q�6�   $	��200��6�   6�   �� 5  "   -   5        $��SemiBold"�5  R   $��	Pretraži��6h   $��	10 0 10 0q�6{   $��20��6�   $��80��6�   6�   �� 5  "   -   5        $��SemiBold"�5  R   $��Poništi��6h   $��	10 0 10 0q�6z   $��20��6�   $��80��6�   6�   5     &   System.Windows.Controls.DataGrid  5     -   5           Name$  tabela��5  �   $ index.html#tabMan��6'   $��1��6R   $��0��6_   !   AlternatingRowBackground! �#daebe8$
��Auto��6�   $��14(�6�   $��Right=�6�   "   
IsReadOnly" . #   AutoGenerateColumns# .  ��6�   �� $ �� UpdateSourceTrigger$$ PropertyChanged=�%   Columns% 5  "   4  .System.Windows.Controls.DataGridTemplateColumn  5  &   ,  &System.Windows.Controls.DataGridColumn&   Width5  /System.Windows.Controls.DataGridLengthConverter$
& Auto 6=   '   Header$' Ikonica��6J   (   CellTemplate( 5  *   �� 5  .   .R�5  2   �� $��20��68   $��20��6D   ��6O   �� *	Ikonica+6l   5  /   5!  '   0	  *System.Windows.Controls.DataGridTextColumn	  5"  &   $
& Auto 69   $' Oznaka��6F   1
  +System.Windows.Controls.DataGridBoundColumn) 
  Binding) 6V   �� *Oznaka+	  5#  &   $
& Auto 69   $' Naziv��6F   ) 6U   �� *Naziv+	  5$  &   $
& Auto 69   $' Tip manifestacije��6F   ) 6a   �� *Tip+	  5%  &   $
& Auto 69   $' Datum održavanja��6F   ) 6`   �� *DatumOdrzavanja+$ {0:dd.MM.yyyy}��5(     �� 5+     $��2��6)   $��0��66   .+�5,  "   �� $��10 5 5 5q�6-   .+�5-  &   �� $ 
Horizontal=�61   .+�5.  *   �� $��0 0 10 0q�60   $��20��6B   $��20��6M   $l��fC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\info32.png��6Y   �� 5/  *   $��Medium"�64   $	��800��6I   $
��Wrap=�6U   wuDa biste prikazali detaljnije informacije o određenoj manifestaciji, pozicionirajte se na nju klikom miša u tabeli.6�   50  '   51  #   � 52  "    53  &   �� 54  *    56  &   �� 57  *   �� 58  *   .+�5<  &   � $��0��6+   $��0��68   * � DataContext* 6H   �� + �� ElementName$+ tabela��$	 SelectedItem�$$ PropertyChanged=� 5=  *   �� 5>  .   �� 5?  .   �� 5@  .   �� 5A  .   �� 5B  .   �� 5C  .   �� 5D  .    5F  *   �� 5G  .   �� 5H  .   .+�5K  *   �� $��5 5 5 5q�64   $��0��6F   $��0��6V   	Oznaka:6l   �� 5L  *   $��5 5 5 5q�64   $��0��6F   $��1��6V   Naziv:6k   �� 5M  *   $��5 5 5 5q�64   $��0��6F   $��2��6V   Opis:6j   �� 5N  *   $��5 5 5 5q�64   $��0��6F   $��3��6V   Tip:6i   �� 5O  *   $��5 5 5 5q�64   $��0��6F   $��4��6V   Mesto održavanja6u   �� 5P  *   
�������$��5 5 5 5q�6D   $��1q�6V   $��1��6j   $��0��6z   ._�5Q  .   �� $��Center=�68   
���iii���6j   �� $	 Oznaka�6�   5R  +   �� 5S  *   
�������$��5 5 5 5q�6D   $��1q�6V   $��1��6k   $��1��6{   ._�5T  .   �� $��Center=�68   
���iii���6j   �� $	 Naziv�6�   5U  +   �� 5V  *   , �� 
IsReadOnly, . $��5 5 5 5q�6D   $��1��6V   $��2��6f   $	��154��6s   - �� TextWrapping$
- Wrap=�6   . �� TextAlignment$. Justify=�5W  +   $��50��6C   
���iii�"/ �� VerticalScrollBarVisibility$
/ Auto=�6d   ��6�   �� $
	 Opis�.��6�   5X  +   �� 5Y  *   
�������$��5 5 5 5q�6D   $��1q�6V   $��1��6k   $��3��6{   ._�5Z  .   �� $��Center=�68   
���iii���6j   �� *Tip+6�   5[  +   �� 5\  *   
�������$��5 5 5 5q�6D   $��1q�6V   $��1��6k   $��4��6{   ._�5]  .   �� $��Center=�68   
���iii���6j   �� $	 MestoString�6�   5^  +   �� 5_  *   {�.  
���iii�$��5 5 5 5q�6Z   $��2��6k   $��5��6   0 d� 	IsChecked0 6�   �� $	 DostupnostZaHendikepirane�.��6�   Dostupna je za hendikepirane6�   �� 5`  *   {�.  
���iii�$��5 5 5 5q�6Z   $��2��6k   $��6��6   0 6�   �� $	 DozvoljenoPusenje�.��6�   Dozvoljeno je pušenje6�   5b  '   � 5e  &   $��0��6+   $��1��68   * 6H   �� $+ tabela��$	 SelectedItem� 5f  *   �� 5g  .   �� 5h  .   �� 5i  .   �� 5j  .   �� 5k  .   �� 5l  .    5n  *   �� 5o  .   �� 5p  .   .+�5s  *   �� $��5 5 5 5q�64   $��0��6E   $��0��6U   
Ikonica:6l   �� 5t  *   $��5 5 5 5q�64   $��0��6E   $��1��6U   Datum održavanja:6u   �� 5u  *   $��5 5 5 5q�64   $��0��6E   $��2��6U   Status služenja alkohola:6}   �� 5v  *   $��5 5 5 5q�64   $��0��6E   $��3��6U   Kategorija cena:6t   �� 5w  *   $��5 5 5 5q�64   $��0��6E   $��4��6U   Očekivana publika:6v   �� 5x  *   $��5 5 5 5q�64   $��0��6E   $��5��6U   Lista etiketa:6r   �� 5z  *   $��1��60   $��0��6@   $��5 0 0 0q�6M   $��20��6_   $��20��6k   ��6v   �� *	Ikonica+6�   �� 5{  *   
�������$��5 5 5 5q�6D   $��1q�6V   $��1��6k   $��1��6{   ._�5|  .   �� 
���iii�$��Center=�6M   ��6j   �� *DatumOdrzavanja+$ {0:dd.MM.yyyy}��6�   5}  +   �� 5~  *   
�������$��5 5 5 5q�6D   $��1q�6V   $��1��6k   $��2��6{   ._�5  .   �� 
���iii�$��Center=�6M   ��6j   �� $	 AlkoholString�6�   5�  +   �� 5�  *   
�������$��5 5 5 5q�6D   $��1q�6V   $��1��6k   $��3��6{   ._�5�  .   �� 
���iii�$��Center=�6M   ��6j   �� $	 
CenaString�6�   5�  +   �� 5�  *   , . $��5 5 5 5q�6D   
���iii�$��1��6j   $��4��6z   ��6�   �� $	 OcekivanaPublika�6�   �� 5�  *   -   5        $��listbox��5�  �   $��1��62   $��5��6B   $��5 5 5 5q�6y   $	��152��6�   $��60��6�   $
��Left=�6�   ��6O   �� $	 ListaEtiketa���5�  .   �� 5�  2   .R�5�  6   �� $ 
Horizontal=�6A   .+�5�  :   �� $��10��6D   $��0 0 5 0q�6O   $��10��6`   ��6l   �� *Boja+�� 5�  :   
���iii���6Y   �� *Oznaka+6s   5�  7   5�  3   5�  +   5�  '   5�  #   5�     5�     5�     �� 5�     $��Tipovi manifestacija��6   .��5�     �  5�     �� 5�  "    5�     �� 5�  "   $��30 �60   �� 5�  "   �� 5�  "   .+�5�     �� $ 
Horizontal=�6)   $��0��6B   $��0��6O   .+�5�  "   �� $��	200 5 0 0q�6(   $	��Top=�6;   $��20��6S   $��20��6^   $n��hC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\question.png��6j    5�  &   �� 5�  *   JHUnesite pojam po kom želite da pretražite prikazanu tabelu. Moguće je�� 6z   GEpretraživanje po oznaci, nazivu i opisu. Pretražuje se pritiskom na�� 5�  x   JHdugme "Pretraži". Pritiskom na dugme "Poništi" se poništava pretraga.5�  +   5�  #   �� 5�  "   -   5        $��searchTipoviTxt��5�  U   $ index.html#tabTip��6*   $��20��6m   $��	10 0 15 0q�6y   $	��200��6�   6�   �� 5�  "   -   5        $��SemiBold"�5�  K   $��	Pretraži��6a   $��	10 0 10 0q�6t   $��20��6�   $��80��6�   6�   �� 5�  "   -   5        $��SemiBold"�5�  K   $��Poništi��6a   $��	10 0 10 0q�6s   $��20��6�   $��80��6�   6�   5�       5�     -   5        $  	tabelaTip��5�  �   $ index.html#tabTip��6'   $��1��6R   ! �#daebe8$
��Auto��6�   $��14(�6�   $��Right=�6�   " . # .  % 5�  "     5�  &   $
& Auto 6=   $' Ikonica��6J   ( 5�  *   �� 5�  .   .R�5�  2   �� $��20��68   $��20��6D   ��6O   �� *	Ikonica+6l   5�  /   5�  '   	  5�  &   $
& Auto 69   $' Oznaka��6F   ) 6V   �� *Oznaka+	  5�  &   $
& Auto 69   $' Naziv��6F   ) 6U   �� *Naziv+	  5�  &   $
& Auto 69   $
' Opis��6F   ) 6T   �� *Opis+5�     �� 5�     $��2��6)   $��0��66   .+�5�  "   �� $��10 5 5 5q�6-   .+�5�  &   �� $ 
Horizontal=�61   .+�5�  *   �� $��0 0 10 0q�60   $��20��6B   $��20��6M   $l��fC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\info32.png��6Y   �� 5�  *   $��Medium"�64   $	��800��6I   $
��Wrap=�6U   nlDa biste prikazali detaljnije informacije o određenom tipu manifestacije, pozicionirajte se na njega klikom�� 6�   miša u tabeli.6�   5�  '   5�  #   � 5�  "   * 6'   �� $+ 	tabelaTip��$	 SelectedItem� 5�  &   �� 5�  *   �� 5�  *   �� 5�  *   �� 5�  *    5�  &   �� 5�  *   $
��Auto �6;   �� 5�  *   $
��Auto �6;   .+�5�  &   �� $��5 5 5 5q�60   $��0��6B   $��0��6R   
Ikonica:6i   �� 5�  &   $��5 5 5 5q�60   $��0��6B   $��1��6R   	Oznaka:6h   �� 5�  &   $��5 5 5 5q�60   $��0��6B   $��2��6R   Naziv:6g   �� 5�  &   $��5 5 5 5q�60   $��0��6B   $��3��6R   Opis:6f   �� 5�  &   $��1��6,   $��0��6<   $��5 0 0 0q�6I   $��20��6[   $��20��6g   ��6r   �� *	Ikonica+6�   �� 5�  &   
�������$��5 5 5 5q�6@   $��1q�6R   $��1��6g   $��1��6w   ._�5�  *   �� 
���iii�$��Center=�6I   ��6f   �� $	 Oznaka�6�   5�  '   �� 5�  &   
�������$��5 5 5 5q�6@   $��1q�6R   $��1��6g   $��2��6w   ._�5�  *   �� 
���iii�$��Center=�6I   ��6f   �� $	 Naziv�6�   5�  '   �� 5�  &   , . $��5 5 5 5q�6@   $��1��6R   $��3��6b   $	��180��6o   $
- Wrap=�6{   
���iii�$. Justify=�5�  )   $	��100��6A   $
/ Auto=�6N   ��6q   �� $
	 Opis�6�   5�  #   5�     5�     5�     �� 5�     $��Etikete��6   .��5�     �  5�     �� 5�  "    5�     �� 5�  "   $��30 �60   �� 5�  "   �� 5�  "   .+�5�     �� $ 
Horizontal=�6)   $��0��6B   $��0��6O   .+�5�  "   �� $��	200 5 0 0q�6(   $	��Top=�6;   $��20��6S   $��20��6^   $n��hC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\question.png��6j    5�  &   �� 5�  *   JHUnesite pojam po kom želite da pretražite prikazanu tabelu. Moguće je�� 6z   ECpretraživanje po oznaci i opisu. Pretražuje se pritiskom na dugme�� 5�  w   DB"Pretraži". Pritiskom na dugme "Poništi" se poništava pretraga.5�  +   5�  #   �� 5   "   -   5        $��searchEtiketeTxt��5   T   $ index.html#tabEt��6*   $��20��6m   $��	10 0 15 0q�6y   $	��200��6�   6�   �� 5  "   -   5        $��SemiBold"�5  L   $��	Pretraži��6b   $��	10 0 10 0q�6u   $��20��6�   $��80��6�   6�   �� 5  "   -   5        $��SemiBold"�5  L   $��Poništi��6b   $��	10 0 10 0q�6t   $��20��6�   $��80��6�   6�   5       5     -   5        $  tabelaEtiketa��5  �   $ index.html#tabEt��6'   $��1��6Q   ! �#daebe8$
��Auto��6�   $��14(�6�   $��Right=�6�   " . # .  % 5  "     5  &   $
& Auto 6=   $
' Boja��6J   ( 5	  *   �� 5
  .   .R�5  2   �� $��1��6<   $��0��6L   $��20��6Y   $��20��6d   $��1��6�   
���   ���6p   �� $
	 Boja�6�   5  /   5  '   	  5  &   $
& Auto 69   $' Oznaka��6F   ) 6V   �� *Oznaka+	  5  &   $
& Auto 69   $
' Opis��6F   ) 6T   �� *Opis+5     �� 5     $��2��6)   $��0��66   .+�5  "   �� $��10 5 5 5q�6-   .+�5  &   �� $ 
Horizontal=�61   .+�5  *   �� $��0 0 10 0q�60   $��20��6B   $��20��6M   $l��fC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\info32.png��6Y   �� 5  *   $��Medium"�64   $	��800��6I   $
��Wrap=�6U   qoDa biste prikazali detaljnije informacije o određenoj etiketi, pozicionirajte se na nju klikom miša u tabeli.6�   5  '   5  #   � 5  "   * 6'   �� $+ tabelaEtiketa��$	 SelectedItem� 5  &   �� 5  *   �� 5  *   �� 5   *    5"  &   �� 5#  *   $
��Auto �6;   �� 5$  *   $
��Auto �6;   .+�5'  &   �� $��5 5 5 5q�60   $��0��6B   $��0��6R   Boja:6f   �� 5(  &   $��5 5 5 5q�60   $��0��6B   $��1��6R   	Oznaka:6h   �� 5)  &   $��5 5 5 5q�60   $��0��6B   $��2��6R   Opis:6f   �� 5+  &   $��1��60   $��0��6@   $��20��6M   $��20��6X   $��1��6   
���   ���6d   �� $
	 Boja�6�   �� 5,  &   
�������$��5 5 5 5q�6@   $��1q�6R   $��1��6g   $��1��6w   ._�5-  *   �� $��Center=�64   
���iii���6f   �� $	 Oznaka�6�   5.  '   �� 5/  &   , . $��5 5 5 5q�6@   $��1��6R   
���iii�$��2��6w   $	��180��6�   $
- Wrap=�6�   $. Justify=�50  )   $	��100��6A   $
/ Auto=�6N   ��6q   �� $
	 Opis�6�   51  #   52     53     54     55     56     57     58     59     