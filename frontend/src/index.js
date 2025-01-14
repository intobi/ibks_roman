import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import 'bootstrap/dist/css/bootstrap.min.css';
import  TicketsProvider  from './context/TicketsContext';

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
  <React.StrictMode>
     <TicketsProvider>
            <App />
        </TicketsProvider>
  </React.StrictMode>
);