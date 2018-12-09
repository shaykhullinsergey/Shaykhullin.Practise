import React from 'react';
import {Provider} from "react-redux";
import {Router, Redirect, Route, Switch, withRouter,} from 'react-router';
import {createBrowserHistory} from "history";
import Lectures from "./pages/lectures";
import Auth from "./pages/auth";
import store from "./redux/store";
import 'bulma/css/bulma.css';
import './App.css';

const history = createBrowserHistory();

const Application = () =>
    <Switch>
        <Route
            exact={true}
            path="/auth"
            render={props => (
                <Auth {...props}/>
            )}
        />
        <Route
            path="/lectures/:sessionId"
            render={props =>
                <Lectures {...props}/>
            }
        />
        <Redirect from="/" to="/auth"/>
    </Switch>;

const App = () =>
    <Provider store={store}>
        <Router history={history}>
            <WrappedApp/>
        </Router>
    </Provider>;

const WrappedApp = withRouter(Application);

export default App;
