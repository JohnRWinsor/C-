   M S B A M L   `   `   `  ����   	MP3Player    MP3Player.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
MP3 Player��$	��338��$	��300��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+�o� $��0��$
��Left=�.@�m� $
��File��.@�m� -   $��Select MP3 File��m� -   $
��Exit���� -    ��Name$ TabControlMain��$��1��$��5q�.@��� -    ��Name$ NowPlayingTabItem��$��Now Playing��.���� $��5q� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ 
AlbumImage��$	��100��$	��100��$��5q��� $��5q�$	��156��$	��210��.+��� $��Title: ��$
��Bold"��� -    ��Name$ 	TitleText��$��0q��� $��Artist: ��$
��Bold"�$��5q��� -   $ 
ArtistText��$��0q��� $��Album: ��$
��Bold"�$��5q��� -   $ 	AlbumText��$��0q��� $��Year: ��$
��Bold"�$��5q��� -	   $ YearText���� -
   $ TagEditingTabItem��$��Tag Editing��.���� $��5q�.+��� -    ��Name$ EditTitleTextBox��$��5q����� *Title+�� -   $ EditArtistTextBox��$��5q����� *Artist+�� -   $ EditAlbumTextBox��$��5q����� *Album+�� -   $ EditYearTextBox��$��5q����� *Year+�� -    ��Name$ SaveChanges��$��Save Changes��$��5q��� $��2��$ 
Horizontal=�$
��Left=�$��	139,3,0,5q�$	��152��.+��� $��Volume: ��$��Center=��� -   	 ��Name$	 VolumeSlider��$	��100��
 � Minimum$
 0Q� � Maximum$	 100Q�$��5q� � Value �� *Volume+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��2��$ 
Horizontal=�$
��Left=�$��10,5,0,5q�.+��� -   $
��Play��$��5q��� -   $��Pause��$��5q��� -   $
��Stop��$��5q�