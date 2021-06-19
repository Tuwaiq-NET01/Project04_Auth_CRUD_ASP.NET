import Welcome from './Components/WelcomePage/Welcome'
import Options from './Components/OptionsPage/Options'
import Feed from './Components/FeedPage/Feed'
import Card from './Components/CardPage/Card'
import Dose from './Components/DosePage/Dose'
import NotFound from './NotFound'
import {BrowserRouter as Router, Switch, Redirect, Route, Link} from "react-router-dom";

const Home = () => {

    return (

        <Router>

                <Switch>
                    <Route exact path="/">
                        <Welcome/>
                    </Route>
                    <Route path="/Feed">
                        <Feed/>
                    </Route>

                    <Route path="/Options">
                        <Options/>
                    </Route>

                    <Route path="/Card">
                        <Card/>
                    </Route>

                    <Route path="/Dose">
                        <Dose/>
                    </Route>

                    <Route component={NotFound}/>
                </Switch>




        </Router>
    )
}

export default Home