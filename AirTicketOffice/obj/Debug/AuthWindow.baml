   M S B A M L   `   `   `  ����J  FAirTicketOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AirTicketOfficeAirTicketOffice  5   	        AirTicketOffice.AuthWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AirTicketOffice     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$<  6Приложение для пользователей��5	   	   $	��450��6.   $	��700��6;    � WindowStartupLocation$ CenterScreen=�6G   .��5
      � 
�������.+�5   
   �� $	��400��6   $��15q�6    
�������$��Center=�6C    �� Padding$ 30q�5      $	��700��6    �� CornerRadius$ 30��6-    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$ 	LightGray��63      ShadowDepth$ 0Q�6E   ._�5      �� .+�5      �� $��Авторизация��6   $��Center=�6/   $��30(�6L   $��Italic$�6Z   $
��Bold"�5      $��0 0 0 20q�6.   � 5      $��0 0 0 20q�6   .+�5      �� -   5         ��Name$ 
Button_Reg��5      $
��Left=�62   $��Регистрация��6M   5      �� 5      $��Right=�6   $��
Войти��6:      MaterialDesignFlatButton#��[  5      5      �� 5      -   5        	 ��Name$	 tbLogin��5      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Введите логин��6+    % !MaterialDesignFloatingHintTextBox#��[ 5      G� 5      -   5         G�Name$ passBox��5      $!
 Введите пароль��6/    ) %MaterialDesignFloatingHintPasswordBox#��[ 5      �� 5      -   5        $ Button_Auth��5      $"��Войти в кабинет��6.   $
��0 20q�6H   6V   5      5      5       5!      