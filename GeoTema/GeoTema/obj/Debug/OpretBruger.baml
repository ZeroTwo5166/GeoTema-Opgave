   M S B A M L   `   `   `  ����B  >GeoTema, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GeoTemaGeoTema  5   	       GeoTema.OpretBruger   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:GeoTema     5   	     � Title$  OpretBruger��5   	   $	��600��6   $	��400��6*   .��5	      �� .+�5
   
   �� $
��30px(�6   $
��Bold"�6$    �� Left$ 94��66   
 �� Top$ 22��6G   OpretBruger6e   �� 5   
   $ 36��6   $	 159��6%   $
��Bold"�66   $��31��6H   $	��114��6T   $
��20px(�6`   
Brugernavn6|   �� 5   
   $ 38��6   $	 214��6%   $
��Bold"�66   $��31��6H   $	��136��6T   $
��20px(�6`   �� 6q   $�Adgangskode��6u   6�   �� 5   
   -   5         ��Name$ 
brugernavn��5      $
��20px(�6&   $	 179��66   $	 164��6H   $	��141��6Y   $
��30px��6e   6u   �� 5   
   -   5        $ adgangskode��5      $
��20px(�6'   $	 179��67   $	 214��6I   $	��141��6Z   $
��30px��6f   �� 5   
   $ 38��6   $	 270��6%   $
��Bold"�66   $��31��6H   $��90��6T   $
��20px(�6_   �� 6p    � Language$ da-dk�6t   $�UserRole��6�   6�   �� 5   
   -   5         ��Name$ ComboBoxUser��5      $	 184��6)   $	 268��6;   $	��136��6L   $��34��6X   .@�5      �� -   5        $��Admin��5   +   $��Admin��6   6;   �� 5      -   5        $��SuperBruger��5   2   $��Super Bruger��6   6H   �� 5      -   5        $��NormalBruger��5   3   $��Normal Bruger��6   6J   5      �� 5   
   -   5         ��Name$ opret��5      $
��20px(�6    $ 38��60   $	 326��6A   $��70��6R   $��30��6]   .��6~   Opret6�   �� 5   
   -   5        $��tilbage��5      $
��20px(�6    $	 304��60   $	 326��6B   $��70��6S   $��30��6^   $��Tilbage��6j   6|   &   System.Windows.Controls.DataGrid  5   
   -	   5        $��datagridUsers��5   N   $ 38��6   $	 395��6$   $	��170��65   $	��324��6B   6f   �� 5   
   -
   5        $
 slet��5      $
��20px(�6   $	 214��6/   $	 326��6A   $��70��6R   $��30��6]   $
��Slet��6i   6x   �� 5   
   $ 36��6   $	 111��6%   $
��Bold"�66   $��31��6H   $	��114��6T   $
��20px(�6`   �� 6q   $�ID��6u   6�   �� 5   
   -   5        $ id��5      $
��20px(�6   $	 179��6.   $	 116��6@   $	��141��6Q   $��30��6]   �� 5   
   $	 143��6   $ 98��6&   -+Brug ID kun for at slette eller at redigere6c   �� 5   
   $ 45��6   $	 374��6%   75Admin = 1101; SuperBruger = 1110; NormalBruger = 10116m   �� 5    
   -   5        $ rediger��5       $
��20px(�6"   $	 122��62   $	 326��6D   $��74��6U   $��30��6`   $��Rediger��6l   5!      5"      