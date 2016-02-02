using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanDataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assigning a variable name to our database tables
            using (var db = new KanbanDataLayerEntities())
            {
                // Looping through each list in database while... 
                foreach (var list in db.Lists)
                {
                    Console.WriteLine(list.Name);
                    //...looping each card for that list
                    foreach (var card in db.Cards)
                    {
                        //aligning the listID as primary and foreign keys. Assigning each card to its list.
                        if (list.ListId == card.ListId)
                        {
                            Console.WriteLine("\t" + card.Text);
                        }
                    }
                }
                //prompts user to add another list/data
                Console.WriteLine("----");
                Console.WriteLine("Please enter list name to add: ");
                var addlistInput = Console.ReadLine();

                //Creating a new instance of list class
                //property of class list "name" is assigned the value "addlistInput"
                var newlistname = new List { Name = addlistInput };
                //Adding the new instance of list class to our list tables
                db.Lists.Add(newlistname);
                //save changes
                db.SaveChanges();
                //reprinting our list of lists with new changes
                foreach (var list in db.Lists)
                {
                    Console.WriteLine(list.Name);
                    //...looping each card for that list
                    foreach (var card in db.Cards)
                    {
                        //aligning the listID as primary and foreign keys. Assigning each card to its list.
                        if (list.ListId == card.ListId)
                        {
                            Console.WriteLine("\t" + card.Text);
                        }
                    }
                }
                Console.WriteLine("---");
                Console.WriteLine("Please enter the list name to delete: ");
                var deletelistinput = Console.ReadLine();

                var deletelistname = db.Lists.Where(u => u.Name == deletelistinput);
                //Adding the new instance of list class to our list tables
                foreach (var u in deletelistname)
                {
                    db.Lists.Remove(u);
                }
                //save changes
                db.SaveChanges();
                foreach (var list in db.Lists)
                {
                    Console.WriteLine(list.Name);
                    //...looping each card for that list
                    foreach (var card in db.Cards)
                    {
                        //aligning the listID as primary and foreign keys. Assigning each card to its list.
                        if (list.ListId == card.ListId)
                        {
                            Console.WriteLine("\t" + card.Text);
                        }
                    }
                }

//                Console.WriteLine("---");
//                Console.WriteLine("Please enter the card name to delete: ");
//                var addcardinput = Console.ReadLine();
//                var addcardrow = db.Set<Card>();
//
//                addcardrow = new Card

            }
        Console.ReadLine();
        }
    }
}
