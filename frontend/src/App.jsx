import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import TicketsPage from './pages/tickets/TicketsPage'; // Сторінка списку тікетів
import './App.css';

const App = () => {
    return (
        <Router>
            <div className="App">
                {/* Навігація або глобальні обгортки можна додати тут */}
                <Routes>
                    {/* Головна сторінка перенаправляє на /tickets */}
                    <Route path="/" element={<Navigate to="/tickets" replace />} />

                    {/* Сторінка зі списком тікетів */}
                    <Route path="/tickets" element={<TicketsPage />} />

                    {/* 404 Сторінка */}
                    <Route path="*" element={<div>404 - Page Not Found</div>} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;