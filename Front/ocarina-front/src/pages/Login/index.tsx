import axios from 'axios';
import { useNavigate } from 'react-router-dom';

import $ from 'jquery';
import './style.css';
import './login';

function Login() {
   {
    }
    return (
        <>
            <div className="page">
                <form method="POST" className="formLogin">
                    <h1>Login</h1>
                    <p>Digite os seus dados de acesso no campo abaixo.</p>
                    <label >E-mail</label>
                    <input id='email' type="email" placeholder="Digite seu e-mail"  />
                    <label >Senha</label>
                    <input id='senha' type="password" placeholder="Digite seu e-mail" />
                    <a href="/">Esqueci minha senha</a>
                    <input type="submit" value="Acessar" className="btn" />
                </form>
            </div>
        </>
    );
}

export default Login;