   M S B A M L   `   `   `  ����L  HMapaManifestacija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MapaManifestacijaMapaManifestacija  5   	       MapaManifestacija.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MapaManifestacija     5   	     � Title$  Prijavljivanje��5   	    � 
ResizeMode$ CanMinimize=�6    $	��390��69   $	��510��6F    � Icon$w qC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\map_icon_Bjj_icon.ico��6R   .��5	      � ��5
   
   �� 5       �� Opacity$	 0.5Q�6    �� ImageSource$o iC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\login_map.jpg��6'    j� Stretch$ UniformToFill=�6�   .+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $	��490��62   .+�5      �� $��5 0 10 0q�6   $��25��6*   $��25��65   $j��dC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\info.png��6A   �� 5      
���   �$	��450��6/    �� TextAlignment$ Justify=�6;   $
��Wrap=�6S   $����U svakom trenutku korišćenja aplikacije možete pristupiti pomoći pozicioniranjem kursora miša na plavu ikonicu sa upitnikom ili pritiskom na dugme F1 na tastaturi.��6h   5      ��5      �� 5       �� Color$ #daebe8��6&   $
 0.75Q�66   5      �� 5      	 �� Padding$	 3q�6   
 �� CornerRadius$
 3��6!   $��140 50 140 60q�62   ���#daebe8$��1q�6_   ��5      �� 5      $ #daebe8��6&   $
 0.75Q�66   ._�5      �� .+�5      �� $��0 5 0 5q�6    $��20(�61   $��SemiBold"�6?   $��Center=�6U   $��Mapa Manifestacija��6r   6�   � 5       $��0 10 0 0q�6   $	��155��6-    � RowDefinitions 5!      �� 5"      $��20 �6,   �� 5#      �� 5$      $��20 �6,   �� 5%      �� 5&       � ColumnDefinitions 5(      �� 5)      .+�5-      �� $��0��6$   $��6 5 5 0q�61   $��Korisničko ime:��6C   �� 5.      $ 
Horizontal=�6%   $��1��6>   $��0��6K   .+�5/      �� -   5        $��UsernameTextBox��5/   }   |�. 
������� J� Opacity$
 0.65Q�6P   $��5 0 5 10q�6_   $	��178��6q   6�   �� 50      $��0 5 0 0q�6$   $	��Top=�65   $��15��6M   $��15��6X   $n��hC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\question.png��6d    � ToolTip 51   "   �� 52   &   $R��LOvo polje služi za unos korisničnog imena izabranog prilikom registracije.��60   54      55      �� 58      $��2��6%   $��6 5 5 0q�62   $��Lozinka:��6D   �� 59      $ 
Horizontal=�6%   $��3��6>   $��0��6K   .+�5:      G� -   5        $��PasswordTextBox��5:   o   $	��178��6*   
�������$
 0.65Q�6N   $��5 0 5 10q�6]   6�   �� 5;      $��0 5 0 0q�6$   $	��Top=�65   $��15��6M   $��15��6X   $n��hC:\Users\Marijana Kolosnjaji\Documents\Visual Studio 2015\Projects\MapaManifestacija\Images\question.png��6d    5<   "   �� 5=   &   B@Ovo polje služi za unos lozinke izabrane prilikom registracije.�� 5>   #   LJRadi sigurnosti, karakteri su prilikom unosa predstavljeni crnim tačkama.6z   5@      5A      �� 5B      -   5        
�������
���   �
�������$
 0.75Q�5B   w   $��SemiBold"�6�   $��
25 10 25 0q�6�   $��4��6�   $��2��6�   $��	Uloguj se��6�   $0 *Potvrda unesenih podataka i prijavljivanje��6�   6  5D      5E      5F      5G      5H      5I      