import React from "react";
import {Link} from "react-router-dom"


function About() {
  return (
    <main>
      <div className="position-relative overflow-hidden p-3 p-md-5 m-md-3 text-center bg-light">
        <div className="col-md-5 p-lg-5 mx-auto my-5">
          <h1 className="display-4 fw-normal">Punny headline</h1>
          <p className="lead fw-normal">
            And an even wittier subheading to boot. Jumpstart your marketing
            efforts with this example based on Apple’s marketing pages.
          </p>
          <Link className="btn btn-outline-secondary" to="/">
            Home
          </Link>
        </div>
        <div className="product-device shadow-sm d-none d-md-block"></div>
        <div className="product-device product-device-2 shadow-sm d-none d-md-block"></div>
      </div>
        
    </main>
  );
}

export default About;
