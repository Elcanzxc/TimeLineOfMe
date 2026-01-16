
import { Books } from "../components/Books";
import type { Book } from "../Models/Book";
import { createBook, deleteBook, getAllBooks, updateBook, type BookRequest } from "../services/books"
import { useEffect, useState } from "react"
import { CreateUpdateBook, Mode } from "../components/CreateUpdateBook";

export default function BooksPage(){

    const defaultValues ={
    title: "",
    description: "",
    author :"",
    publishedDate: "",
  } as Book
  const [values,setValues] = useState<Book>(defaultValues)

   const[books,setBooks] = useState<Book[]>([]);
   const[loading,setLoading] = useState(true);
     
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [mode, setMode] = useState(Mode.Create);

  const handleCreateBook = async (request : BookRequest) =>{
    await createBook(request)

    closeModal();
    const books = await getAllBooks();
    setBooks(books);
  }

  const handleUpdateBook = async (id : string,request : BookRequest) =>{
  await updateBook(id,request);
  closeModal();

    const books = await getAllBooks();
    setBooks(books);
  }

  const handleDeleteBook = async (id: string) => {
     await deleteBook(id);
    closeModal();

    const books = await getAllBooks();
    setBooks(books);
  }

    const openModal =  () =>{
        setMode(Mode.Create);
    setIsModalOpen(true);
  }


    const closeModal =  () =>{
    setValues(defaultValues)
    setIsModalOpen(false);
  }

const openEditModal = (book:Book) =>{
    setMode(Mode.Edit);
    setValues(book);
    setIsModalOpen(true);
}


    useEffect( () => {
           const getBooks = async () => {
            const books = await getAllBooks();
            setLoading(false);
            setBooks(books);
           };
           getBooks();
    },[])


    return(
        <div>
        <button onClick={openModal}>Add book</button>
         
         <CreateUpdateBook 
          mode={mode}
          values={values} 
          isModalOpen={isModalOpen} 
          handleCreate={handleCreateBook} 
          handleUpdate={handleUpdateBook}
          handleCancel={closeModal}
         />
         {loading? (<div>Loading...</div>): (  <Books books={books} handleOpen={openEditModal} handleDelete={handleDeleteBook}/>)}
       
        </div>
    )
}