import React, { Component } from "react";
import PropTypes from 'prop-types';

class Header extends Component {

  /*static defaultProps = {
    title: "Varsayılan başlık",
    slogan: "Varsayılan slogan"
  }*/
  render() {
    
    return (
      <section className="py-5 text-center container">
        <div className="row py-lg-5">
          <div className="col-lg-6 col-md-8 mx-auto">
            <h1 className="fw-light">{this.props.title}</h1>
            <p className="lead text-muted"> {this.props.slogan}
            </p>
          </div>
        </div>
      </section>
    );
  }
}

Header.propTypes = {
  title: PropTypes.string,
  slogan: PropTypes.string
}
export default Header;
