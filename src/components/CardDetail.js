import React, { useState , useEffect} from "react";
import {useParams, Link} from 'react-router-dom'

const CardDetail = (props) => {

    const [book, setBook] = useState({})

    const {id} = useParams()

 

        useEffect(() => {
            const getBook = () => {
                fetch(`https://localhost:44386/api/books/${id}`)
                  .then((response) => response.json())
                  .then((data) => setBook(data.bookListResponse));
              };
            getBook();
          }, [id]);
        

  return (
    <main>
      <div className="px-4 pt-5 my-5 text-center border-bottom">
        <h1 className="display-4 fw-bold">{book.title}</h1>
        <div className="col-lg-6 mx-auto">
          <p className="lead mb-4">
            {book.about}
          </p>
          <div className="d-grid gap-2 d-sm-flex justify-content-sm-center mb-5">
          <Link className="btn btn-outline-secondary" to="/">
            Ana Sayfa
          </Link>
          </div>
        </div>
        <div className="overflow-hidden">
          <div className="container px-5">
            <img
              src= {book.imagePath}
              className="img-fluid border rounded-3 shadow-lg mb-4"
              alt={book.title}
              loading="lazy"
              width="500"
              height="300"
            />
          </div>
        </div>
      </div>
    </main>
  );
};

export default CardDetail;
