using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Model;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    class Controller
    {
        Database db;
        public Controller()
        {
            db = new Database();
        }
        public string GetBook(string bookname)
        {                
            Book rez = db.Find(bookname);
          
            if(rez!=null)
            {
                return rez.ToString();
            }
            return "Книга не найдена!";
        }

        public void NewBook()
        {
            Add add = new Add();
            Book book = null;
            DialogResult rez = add.ShowDialog();
            if ( rez== DialogResult.OK)
            {
                book = add.GetNewBook();
                if (book == null)
                {
                    MessageBox.Show("Null");
                    return;
                }
            }
            else if (rez == DialogResult.Cancel)
            {
               return;
            }
            db.AddBook(book);   



        }

        public void ViewBookList()
        {
            db=new Database();
            BookList bookList = new BookList(db);
            bookList.ShowDialog();
        }
    }
}
