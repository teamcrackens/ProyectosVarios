import createHistory from 'history/createBrowserHistory'
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Router } from 'react-router'
import App from './App';
import './index.css';
import registerServiceWorker from './registerServiceWorker';


const historial = createHistory()
ReactDOM.render(
  <Router history={historial}>
    <App />
  </Router>,
  document.getElementById('root') as HTMLElement
);
registerServiceWorker();
