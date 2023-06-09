﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Selecbox_lec7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();

        Student selectedStudent = null;

        
        public MainWindow()
        {
            InitializeComponent();

            // How to aadd items to a selection box.
            // add to a selection by Accessing its Items List

            Preload();
            DisplayToListBox();
            DisplayToListBox();// Testing for index
            DisplayToComboBox();

            //Automaticaly select the first item in our listbox on load.

            lbDisplay.SelectedIndex = 0;
            cbDisplay.SelectedIndex = 0;
        }


        private void btnAddTolist_Click(object sender, RoutedEventArgs e)
        {
            string userInput = txtToAdd.Text;

            lbDisplay.Items.Add(userInput);
        }

        public void DisplayToListBox()
        {


            //Use the. Clear() method to clear all items from our listbox
            lbDisplay.Items.Clear();

            for (int i = 0; i < students.Count; i++)
            {
                string firstName = students[i].FirstName;
                string lastName = students[i].LastName;
                string fullName = firstName + " " + lastName;

                lbDisplay.Items.Add(fullName);
            }

        }

        public void DisplayToComboBox()
        {


            //Use the. Clear() method to clear all items from our listbox
            cbDisplay.Items.Clear();

            for (int i = 0; i < students.Count; i++)
            {
                string firstName = students[i].FirstName;
                string lastName = students[i].LastName;
                string fullName = firstName + " " + lastName;

                cbDisplay.Items.Add(fullName);
            }

        }


        //Preload 
        public void Preload()
        {
            //Student student1 = new Student()
            //{
            //    FirstName = "will",
            //    LastName = "Cram",
            //    CSIGrade = 67,
            //    GenEdGrade = 97
            //};
            Student student = new Student("Will", "Cram", 101, 23);

            students.Add(student);
            students.Add(new Student("Hannah", "Angel", 101, 99));
            students.Add(new Student("Dylan", "Register", 101, 99));
            students.Add(new Student("Kris", "Taniguchi", 101, 99));



        }

        private void btnDisplayStudent_Click(object sender, RoutedEventArgs e)
        {
            //You can access the selected item, but using .selectedIndex
            int selectedIndex = lbDisplay.SelectedIndex;
            
            if(selectedIndex < 0)
            {
                MessageBox.Show("Please select a name from the list box");

            }
            else
            {
                DisplayStudentInformation(selectedStudent);
                
            }


            
        }
        public void DisplayStudentInformation(Student student)
        {
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtCSIGrade.Text = student.CSIGrade.ToString();
            txtGenEdGrade.Text = student.GenEdGrade.ToString();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            string csi = txtCSIGrade.Text;
            string gened = txtGenEdGrade.Text;

            int genEdGrade = int.Parse(gened);
            int csigrade = int.Parse(csi);


            //I want to create a new instance of student


            //Add our text information to it

            //Add it to our students List
            students.Add(new Student(fName, lName, csigrade, genEdGrade));

            //Then see the name appear in our list box
            DisplayToListBox();

        }

        private void btnRemoveSelectedStudent_Click(object sender, RoutedEventArgs e)
        {
            // Remove by index
            //int selectedIndex = lbDisplay.SelectedIndex;
            //students.RemoveAt(selectedIndex);


            //Remove by object

            int selectedIndex = lbDisplay.SelectedIndex;
            //Student selectedStudent = students[selectedIndex];
            students.Remove(selectedStudent);

            DisplayToListBox();
        }

        public void DisplayUpdatedInformation(int selectedIndex)
        {

            selectedStudent = students[selectedIndex];

            DisplayStudentInformation(selectedStudent);

        }

        //This methaod runs when we item selected inthe listbox chnages
        private void lbDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayUpdatedInformation(lbDisplay.SelectedIndex);

        }

        private void cbDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DisplayUpdatedInformation(lbDisplay.SelectedIndex);
        }
    }
}
