   M S B A M L   `   `   `  ���� G  CMatchingDash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MatchingDash.SharedMatchingDash.Shared  T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls $    MatchingDash.Views.DetailsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8
Controller!clr-namespace:MatchingDash.Shared     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  f bGalaSoft.MvvmLight.Platform, Version=5.2.0.37226, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  $	��900��$
��1200��  � Title$  DETAILS VIEW�� � DataContext �� *Result+   Locator �� Source# [  .��%  MahApps.Metro.Controls.FlipView  $
��Auto��   IsBannerEnabled . $��0, 0, 10, 0q�@��  � RowDefinitions �� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $	��100 ��� $��60 ��� $��* �.+��� $��STUDENT DETAILS  ��$	��Top=�$��Center=�$
��Auto��$��0��$
��Bold"�$��20(�$
��Auto���� $��
First Name��$
��Left=�$	��Top=�$��43��$��1��$��10,7,0,0q�$	��103���� $
��Left=�$	��Top=�$��43��$��1��$��	145,7,0,0q�$	��194������ *Step2Student.FirstName+�� $��	Last Name��$
��Left=�$	��Top=�$��40��$��1��$��
364,10,0,0q�$��99���� $
��Left=�$	��Top=�$��40��$��1��$��
482,10,0,0q�$	��194������ *Step2Student.LastName+�� $��1��$��	UNT Email��$
��Left=�$��
700,14,0,0q�$	��Top=�$��36��$��97���� $��1��$
��Left=�$��
818,14,0,0q�$	��Top=�$��40��$	��318������ *Step2Student.Email+�� $��2��$��Major(math or science)��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��187��$��40���� $��2��$
��Left=�$��
202,10,0,0q�$	��Top=�$��40��$	��145������ *Step2Student.Major+�� $��Mobile Phone��$
��Left=�$��
367,10,0,0q�$��2��$	��Top=�$	��121��$��40���� $
��Left=�$��
506,10,0,0q�$��2��$	��Top=�$��36��$	��189������ *Step2Student.Phone+�� $)��#Do You Have Your Own Transportation��$
��Left=�$��
734,10,0,0q�$��2��$	��Top=�$	��292��$��40���� $
��Left=�$��1046,10,0,0q�$��2��$	��Top=�$��36��$	��104������ *Step2Student.Transportation+�� $:��4If Neccessary, would you be willing to drive someone��$
��Left=�$��	15,10,0,0q�$��3��$	��Top=�$	��414��$��40���� $
��Left=�$��
458,10,0,0q�$��3��$	��Top=�$��36��$��88������ *Step2Student.WillingToDrive+�� $7��1If necessary, would you be willing to teach alone��$
��Left=�$��
567,10,0,0q�$��3��$	��Top=�$	��364��$��40���� $
��Left=�$��
953,10,0,0q�$��3��$	��Top=�$��36��$��86������ *Step2Student.WillingToTeach+�� $��Preferred Days��$
��Left=�$��
818,10,0,0q�$��4��$	��Top=�$��40���� $
��Left=�$��
953,10,0,0q�$��4��$��36��$	��Top=����� *Step2Student.PreferredDays+�� $��Do you live on campus��$
��Left=�$��	15,10,0,0q�$��4��$	��Top=�$	��182��$��40���� $
��Left=�$��
236,10,0,0q�$��4��$	��Top=�$��36��$��74������ *Step2Student.Campus+�� $%��If no, what town do you live in��$
��Left=�$��
346,10,0,0q�$��4��$	��Top=�$	��237��$��40���� $
��Left=�$��
614,10,0,0q�$��4��$	��Top=�$��36��$	��170������ *Step2Student.Town+�� $W��QPlease rank your district preference(1-4. 1=most preferred and 4=least preffered)��$
��Left=�$��	10,10,0,0q�$��5��$	��Top=�$	��624��$��35���� $��Denton��$
��Left=�$��	19,50,0,0q�$��5��$	��Top=�$��72��$��40���� $
��Left=�$��
111,41,0,0q�$��5��$	��Top=�$��36��$��69������ *Step2Student.DistrictDenton+�� $��Forth Worth��$
��Left=�$��
202,50,0,0q�$��5��$	��Top=�$	��108��$��40���� $
��Left=�$��
346,41,0,0q�$��5��$	��Top=�$��36��$��83������ *!Step2Student.DistrictForthWorth+�� $��
Lewisville��$
��Left=�$��
464,50,0,0q�$��5��$	��Top=�$��82��$��40���� $
��Left=�$��
594,41,0,0q�$��5��$	��Top=�$��36��$��82������ *!Step2Student.DistrictLewisville+�� $��McKinney��$
��Left=�$��
688,50,0,0q�$��5��$	��Top=�$��96��$��40���� $
��Left=�$��
823,41,0,0q�$��5��$	��Top=�$��36��$��96������ *Step2Student.DistrictMckinney+�� $J��DAnything else you need to know for scheduling your field placement ?��$
��Left=�$��	19,10,0,0q�$��6��$	��Top=�$	��514��$��40���� $
��Left=�$��
567,10,0,0q�$��6��$	��Top=�$��36��$	��394������ *%#Step2Student.AnythingElseScheduling+&   System.Windows.Controls.DataGrid  -   $��step2Stu��$��7��$
��Left=�$	��Top=�$	��750��$	��320��$
��Auto��   AutoGenerateColumns .   �� ClearTypeHint$ Enabled=�&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�   HeadersVisibility$	 All=�$��
111,10,0,0q����� *Step2Student.Schedule+	 �� Mode$	 TwoWay=�����   MetroDataGrid
 �� BasedOn#
 [  �� 
TargetType"  .���  �� Property  �@ AlternatingRowBackground  GrayBrush10 �� Value# �     RowStyle ��   MetroDataGridRow#
 [ )  #System.Windows.Controls.DataGridRow"     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 HOUR��   
IsReadOnly .    MinWidth$	 200Q�   
FontWeight$
 Bold"�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Time+4  .System.Windows.Controls.DataGridCheckBoxColumn    MetroDataGridCheckBox   ElementStyle# �     EditingElementStyle# �  $ MONDAY��$	 100Q� �� *Monday+ �� UpdateSourceTrigger$ PropertyChanged=�  # �  # �  $ TUESDAY��$	 100Q� �� *	Tuesday+$ PropertyChanged=�  # �  # �  $ 	WEDNESDAY��$	 100Q� �� *	Wednesday+$ PropertyChanged=�  # �  # �  $ THURSDAY��$	 100Q� �� *
Thursday+$ PropertyChanged=�  # �  # �  $ FRIDAY��$	 100Q� �� *Friday+$ PropertyChanged=��  �� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��* �.+��� $��TEACHER DETAILS  ��$	��Top=�$��Center=�$
��Auto��$��0��$
��Bold"�$��20(�$
��Auto��$��482,10,462,0q��� $��
First Name��$
��Left=�$	��Top=�$��31��$��1��$��10,7,0,0q�$
��Auto���� $
��Left=�$	��Top=�$��35��$��1��$��	145,7,0,0q�$
��Auto������ *Step2Teacher.FirstName+�� $��	Last Name��$
��Left=�$	��Top=�$��40��$��1��$��
364,10,0,0q�$
��Auto���� $
��Left=�$	��Top=�$��35��$��1��$��
482,10,0,0q�$
��Auto������ *Step2Teacher.LastName+�� $��1��$��Email��$
��Left=�$��
700,14,0,0q�$	��Top=�$��36��$
��Auto���� $��1��$
��Left=�$��
818,14,0,0q�$	��Top=�$��34��$
��Auto������ *Step2Teacher.Email+�� $��2��$��Grade and Subject��$
��Left=�$��	10,10,0,0q�$	��Top=�$��36��$
��Auto���� $��2��$
��Left=�$��
202,10,0,0q�$	��Top=�$��36��$
��Auto������ *Step2Teacher.Course+�� $��School Phone��$
��Left=�$��
367,10,0,0q�$��2��$	��Top=�$��36��$
��Auto���� $
��Left=�$��
506,10,0,0q�$��2��$	��Top=�$��36��$
��Auto������ *Step2Teacher.SchoolPhone+�� $��Preferred Contact��$
��Left=�$��
864,10,0,0q�$��2��$	��Top=�$��36��$
��Auto���� $
��Left=�$��1046,10,0,0q�$��2��$	��Top=�$��36��$
��Auto������ *Step2Teacher.PreferredContact+�� $��Address��$
��Left=�$��	15,10,0,0q�$��3��$	��Top=�$��36��$
��Auto���� $
��Left=�$��
145,10,0,0q�$��3��$	��Top=�$��36��$
��Auto������ *Step2Teacher.School+�� $0��*Willing to work more than pair of students��$
��Left=�$��
567,10,0,0q�$��3��$	��Top=�$��36��$
��Auto���� $
��Left=�$��
953,10,0,0q�$��3��$	��Top=�$��36��$
��Auto������ *Step2Teacher.Pair+�� $��Room Number��$
��Left=�$��	15,10,0,0q�$��4��$	��Top=�$��36��$
��Auto���� $
��Left=�$��
164,10,0,0q�$��4��$	��Top=�$��36��$
��Auto������ *Step2Teacher.Room+�� $��
Cell Phone��$
��Left=�$��
346,10,0,0q�$��4��$	��Top=�$��36��$
��Auto���� $
��Left=�$��
482,10,0,0q�$��4��$	��Top=�$��26��$
��Auto������ *Step2Teacher.Phone+�� $��School District��$
��Left=�$��
818,10,0,0q�$��4��$	��Top=�$��36��$
��Auto���� $
��Left=�$��
966,10,0,0q�$��4��$	��Top=�$��36��$
��Auto������ *Step2Teacher.District+  $��6��$
��Left=�$	��Top=�$	��750��$
��Auto��$	��400�� .     
IsReadOnly . $ Enabled=�$ Display=�$	 All=�$��111,10,333,34q����� *Step2Teacher.Schedule+$	 TwoWay=����� #
 [ "  .���   �@ AlternatingRowBackground# �   �� #
 [ "     $
 DAYS��$	 140Q� �� *Days+$	 OneWay=�  $ 	Sart Time�� . $	 120Q�$
 Bold"� �� *	StartTime+  $ End Time�� . $	 120Q�$
 Bold"� �� *	EndTime+  $ SUBJECT��$	 140Q� �� *	Subject+$	 OneWay=�  $ GRADE��$	 100Q� �� *Grade+$	 OneWay=�