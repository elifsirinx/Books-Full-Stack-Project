import React, {useContext} from "react";
import { BrowserRouter as Router, Switch, Route} from "react-router-dom";
import Navbar from "./components/Navbar";
import Header from "./components/Header";
import Search from "./components/Search";
import CardList from "./components/CardList";
import Footer from "./components/Footer";
import About from "./components/About";

import KisiselGelisim from "./components/KisiselGelisim";
import NotFound from "./components/NotFound";
import CardDetail from "./components/CardDetail";
import GenreList from "./components/GenreList";
import { BookContext  } from "./contexts/BookContext";



const App = () => {

  const { loading } = useContext(BookContext)


  return (

    <Router basename = {process.env.PUBLIC_URL}>
      <>
        <Navbar />
        <main>
          <div className="album py-5 bg-light">
            <div className="container">
              <Switch>
                <Route exact path="/">
                  <Header title="ELFSİ KİTAP" slogan="Haydii gel yeni bir dost edinnn! :)" />
                  {loading ? (
                    <div className="spinner-border" role="status">
                      <span className="visually-hidden">Loading...</span>
                    </div>
                  ) : (
                    <CardList />
                  )}
                </Route>
                <Route path="/About" component= {About} />
                <Route path="/KisiselGelisim" component = {KisiselGelisim} />
                
                <Route path="/Search">
                  <Search />
                  {loading ? (
                    <div className="spinner-border" role="status">
                      <span className="visually-hidden">Loading...</span>
                    </div>
                  ) : (
                    <CardList  />
                  )}
                </Route>



                <Route path="/genre/:id" component = {GenreList} />  
               

                <Route path = "/books/:id" component = {CardDetail}/>
              
                <Route component={NotFound}/>
              </Switch>
            </div>
          </div>
        </main>
        <Footer />
      </>
    </Router>
    
  );
};

/*       <GenreList />

                  {loading ? (
                    <div className="spinner-border" role="status">
                      <span className="visually-hidden">Loading..</span>
                      
                    </div>
                  ) : (
                    <CardList  />
                  )}*/

export default App;
