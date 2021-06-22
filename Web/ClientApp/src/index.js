import React from 'react';
import ReactDOM from 'react-dom';
// import registerServiceWorker from './registerServiceWorker';
import { unregister } from './registerServiceWorker';

import { BrowserRouter as Router } from 'react-router-dom';
import './assets/base.css';
import Main from './VulnViewPages/Main';
import configureStore from './config/configureStore';
import { Provider } from 'react-redux';

const store = configureStore();
const rootElement = document.getElementById('root');

const renderApp = Component => {
  ReactDOM.render(
    <Provider store={store}>
      <Router basename={document.getElementsByTagName("base")[0].getAttribute('href')}>
        <Component />
      </Router>
    </Provider>,
    rootElement
  );
};

renderApp(Main);

if (module.hot) {
  module.hot.accept('./VulnViewPages/Main', () => {
    const NextApp = require('./VulnViewPages/Main').default;
    renderApp(NextApp);
  });
}
unregister();
