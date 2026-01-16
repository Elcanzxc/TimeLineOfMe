import type { Book } from '../Models/Book'
import { CardTitle } from './Cardtitle';


interface Props{
    books : Book[]
    handleDelete: (id:string) => void;
    handleOpen: (book:Book) => void;


}

export const Books = ({books, handleDelete ,handleOpen}:Props) =>{
    return (
            <div className="cards">
               {books.map((book: Book) => (
                          <div key={book.id} className="card">
                             <CardTitle
                             title={book.title}/>

                           <p>{book.description}</p>

                           <div className='card_buttons'>
                                 <button onClick={() => {handleOpen(book)}} style={{flex:1}}>Edit</button>
                                 <button  onClick={() => {handleDelete(book.id)}} style={{flex:1}}>Delete</button>
                           </div>

                          </div>
                 ))}
            </div>
    )
}