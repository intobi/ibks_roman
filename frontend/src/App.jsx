import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import TicketsPage from './pages/tickets/TicketsPage'; 
import TicketEditPage from './pages/ticketEdit/TicketEditPage';
import './App.css';

const App = () => {
    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path="/" element={<Navigate to="/tickets" replace />} />
                    <Route path="/tickets" element={<TicketsPage />} />
                    <Route path="/tickets/new" element={<TicketEditPage />} />
                    <Route path="/tickets/edit/:id" element={<TicketEditPage />} />
                    <Route path="*" element={<div>404 - Page Not Found</div>} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;