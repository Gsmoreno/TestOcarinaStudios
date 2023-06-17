import './style.css';
import Fogo from '../../assets/fogo.png'
import $ from 'jquery';
import { useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';
function Cadastro() {

    let axiosConfig = {
        headers: {
            'Content-Type': 'application/json;charset=UTF-8',
        }
    };

    useEffect(() => {
        $("#finalizado").on('click', function () {
            if ($('#finalizado').is(':checked') == true) {
                $(".end-date").hide();
            } else {
                $(".end-date").show();
            }
        });
    }, [])

    const navigate = useNavigate();
    const HandleClick = async () => {
        var name = $("#nome").val();
        var caloriesBurned = $("#cal").val();
        var finished = $("#data").val();

        var data =
        {
            name,
            caloriesBurned,
            finished,

        }
        debugger;

        axios.post('https://localhost:5000/api/Exercise/CadastraExercise', data, axiosConfig)
            .then((response) => {
                console.log(response); // Verifique a resposta do servidor
                alert("Exercicio Cadastrado");
                navigate("/dashboard");
            })
            .catch((error) => {
                console.log(error); // Exiba o erro no console
                // Lógica de tratamento de erro, se necessário
            });





    }

    return (
        <>
            <div className="pageC">
                <Link to="/dashboard">
                    <h2>Voltar</h2>
                </Link>
                <h1>ADICIONAR EXERCÍCIO</h1>

                <form className="form">
                    <div className="top">
                        <label className="title-label">NOME</label>

                        <input id='nome' className="name-input" />

                    </div>

                    <div className="medium">
                        <div className="lose-calories">
                            <label className="title-label">CALORIAS PERDIDAS</label>
                            <input id='cal' type="text" className="lose-calories-input" />
                        </div>


                        <div className="end-date">
                            <label className="title-label">DATA FINALIZAÇÃO</label>
                            <input id='data' type="date" className="end-data-input" />
                        </div>

                    </div>

                    <div className="end-form">
                        <input className='end-form input:jacket' id='finalizado' type='checkbox' />
                        <p className='title-label'>NÃO FINALIZADO</p>


                        <button onClick={HandleClick} type='submit' className='button-submit'>
                            Confirmar
                        </button>

                    </div>


                </form>

                <div className="white-ball">
                    <img className="fogo" src={Fogo} />
                </div>
            </div>
        </>
    );
}

export default Cadastro;