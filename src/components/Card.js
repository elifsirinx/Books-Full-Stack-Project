import React from "react";
import { Link } from "react-router-dom";

const Card = (props) => {

  const{imagePath,title,about,rating, id} = props.book

  
  const truncateString = (str, num) => {
    if (str.length > num) {
      return str.slice(0, num) + "...";
    } else {
      return str;
    }
  }

  
    return (
      <div className="card shadow-sm">
        <img alt={title} src={imagePath}/>
        
        <div className="card-body">
        <h5 className = "card-title">{title}</h5>
          <p className="card-text">{truncateString(about,150)}
          </p>
          <div className="d-flex justify-content-between align-items-center">
            <div className="btn-group">
              <Link to={`/books/${id}`} className="btn btn-sm btn-outline-secondary">
                Görüntüle
              </Link>
            </div>
            <small className="text-muted">{rating}</small>
          </div>
        </div>
      </div>
    );
  }

export default Card
