import React, { useContext } from "react";
import { Link } from "react-router-dom";
import { BookContext } from "../contexts/BookContext";


const Navbar = () => {
  const { getBooks } = useContext(BookContext);
  const { genres } = useContext(BookContext);
  const { publishers } = useContext(BookContext);



  return (
    <header>
      <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
        <div onClick={getBooks} className="container">
          <Link className="navbar-brand" to="/">
            ELFSİ
          </Link>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNavDropdown"
            aria-controls="navbarNavDropdown"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNavDropdown">
            <ul className="navbar-nav ms-auto">
              <li onClick={getBooks} className="nav-item">
                <Link className="nav-link active" aria-current="page" to="/">
                  Kitaplar
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/Search">
                  Kitap Ara
                </Link>
              </li>
              <li className="nav-item dropdown">
                <Link
                  className="nav-link dropdown-toggle"
                  to="#"
                  id="navbarDropdownMenuLink"
                  role="button"
                  data-bs-toggle="dropdown"
                  aria-expanded="false"
                >
                  Yayınevleri
                </Link>
                <ul
                  className="dropdown-menu"
                  aria-labelledby="navbarDropdownMenuLink"
                >
                  <li>
                    {publishers.map(function (publisher) {
                      return (
                       
                        <div className="col" key={publisher.id}>
                          <Link 
                            to= {`/publisher/${publisher.id}`}
                            className="btn btn-sm btn-outline-secondary"
                            
                          >
                            {publisher.name}
                          </Link>
                        
                  
                
                        </div>
                      );
                    })}
                  </li>
                </ul>
              </li>
              <li className="nav-item dropdown">
                <Link
                  className="nav-link dropdown-toggle"
                  to="#"
                  id="navbarDropdownMenuLink"
                  role="button"
                  data-bs-toggle="dropdown"
                  aria-expanded="false"
                >
                  Türler
                </Link>
                <ul
                  className="dropdown-menu"
                  aria-labelledby="navbarDropdownMenuLink"
                >
                  <li>
                    {genres.map(function (genre) {
                      return (
                       
                        <div className="col" key={genre.id}>
                          <Link className="dropdown-item"
                            to= {`/genre/${genre.id}`}
                            className="btn btn-sm btn-outline-secondary"
                          >
                            {genre.name}
                          </Link>
                        
                  
                
                        </div>
                      );
                    })}
                  </li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </header>
  );
};

export default Navbar;
