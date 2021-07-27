import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import "bootstrap/dist/css/bootstrap.min.css";
import { BookProvider } from "./contexts/BookContext";
/*import {BrowserRouter, Route} from 'react-router-dom';


ReactDOM.render(
  <BrowserRouter>
    <Route path ="/" component={App} />
  </BrowserRouter>,
  document.getElementById('root')
);*/

ReactDOM.render(
  <React.StrictMode>
    <BookProvider>
      <App />
    </BookProvider>
  </React.StrictMode>,
  document.getElementById("root")
);
