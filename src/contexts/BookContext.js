import React, {createContext, useState, useEffect} from "react"

export const BookContext = createContext()


export const BookProvider = (props) => {

    const [books, setBooks] = useState([]); 
    const [genres, setGenres] = useState([]); 
    const [publishers, setPublishers] = useState([]); 
    const [loading, setLoading] = useState(false);
  
    useEffect(() => {
      getBooks();
      getGenres();
      getPublishers();
      
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

    const getGenres = () => {
      setLoading(true);
      fetch("https://localhost:44386/api/genres")
        .then((response) => response.json())
        .then((data) => {
          //this.setState({books: data.results, loading:false}))
          setGenres(data);
          setLoading(false);
        });
    };
  
    const getPublishers = () => {
      setLoading(true);
      fetch("https://localhost:44386/api/publishers")
        .then((response) => response.json())
        .then((data) => {
          //this.setState({books: data.results, loading:false}))
          setPublishers(data.publishers);
          setLoading(false);
        });
    };
  
    const searchBook = (term) => {
      fetch(`https://localhost:44386/api/books/getbookbybooktitle/${term}`)
        .then((response) => response.json())
        .then((data) => setBooks(data));
    };

    /*const getBooksFromGenre = (id) => {
      fetch(`https://localhost:44386/api/books/getbookbybookgenreid/${id}`)
        .then((response) => response.json())
        .then((data) => setBooks(data));
    };
*/




    return (

        <BookContext.Provider value={{
            books,
            searchBook,
            loading,
            getBooks,
            getGenres,
            genres,
           // getBooksFromGenre,
            publishers,
            getPublishers

        }}>
            {props.children}
        </BookContext.Provider>
        
    )
}