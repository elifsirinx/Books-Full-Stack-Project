import React, {createContext, useState, useEffect} from "react"

export const BookContext = createContext()


export const BookProvider = (props) => {

    const [books, setBooks] = useState([]); 
    const [loading, setLoading] = useState(false);
  
    useEffect(() => {
      getBooks();
    }, []);
  
    const getBooks = () => {
      setLoading(true);
      fetch("https://localhost:44386/api/books")
        .then((response) => response.json())
        .then((data) => {
          //this.setState({books: data.results, loading:false}))
          setBooks(data.results);
          setLoading(false);
        });
    };
  
    const searchBook = (term) => {
      fetch(`https://localhost:44386/api/books/getbookbybooktitle/${term}`)
        .then((response) => response.json())
        .then((data) => setBooks(data));
    };

    return (

        <BookContext.Provider value={{
            books,
            searchBook,
            loading,
            getBooks
        }}>
            {props.children}
        </BookContext.Provider>
        
    )
}