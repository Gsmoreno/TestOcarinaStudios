import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './pages/Login/index';
import Dashboard from './pages/Dashboard/index';



function Routers() {
    return (
        <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Login />} />
                    <Route path="/" element={<Dashboard />} />
                </Routes>
        </BrowserRouter>
    );
}
export default Routers;