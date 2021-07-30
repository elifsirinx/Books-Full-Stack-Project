import React, { useContext } from "react";
import { BookContext } from "../contexts/BookContext";
import {useParams} from 'react-router-dom';
import CardList from "./CardList";


const GenreList = () => {
  //const { getBooksFromGenre } = useContext(BookContext);
  const {loading} = useContext(BookContext)
  const {id} = useParams()
 

  return (
    <div> {id}
      
      {loading ? (
        <div className="spinner-border" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
      ) : (
        <CardList  />
      
      )}
   </div>
  );
};

export default GenreList;