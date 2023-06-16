import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './pages/Login/index';
import Cadastro from './pages/Cadastro/index';
import Dashboard from './pages/Dashboard/index';
import Main from './pages/Main/index';




function Routers() {
    return (
        <BrowserRouter>
                <Routes>
<<<<<<< HEAD
                    <Route path="/" element={<Login />} />
                    <Route path="/cadastro" element={<Cadastro />} />
                    <Route path="/main" element={<Main />} />
                    <Route path="/" element={<Dashboard />} />
=======
                    
                    <Route path="/dashboard" element={<Dashboard />} />
>>>>>>> 6a9f1a5363b9f9318cbf1ea0ad9a45b3669bdb21
                </Routes>
        </BrowserRouter>
    );
}
export default Routers;