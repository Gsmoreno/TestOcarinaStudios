import './style.css';
import Fogo from '../../assets/fogo.png'

function Cadastro() {   
    return (
        <>
            <div className="page">
                <h1>ADICIONAR EXERCÍCIO</h1>
                <form className="form">
                    <div className="top">
                        <label className="title-label">NOME</label>            
                        
                        <input className="name-input"/>
                        
                    </div>

                    <div className="medium">
                        <div className="lose-calories">
                            <label className="title-label">CALORIAS PERDIDAS</label>
                            <input type="text" className="lose-calories-input"/>
                        </div>                  
                        

                        <div className="end-date">
                            <label className="title-label">DATA FINALIZAÇÃO</label>
                            <input type="text" className="end-data-input" />
                        </div>                        
                                 
                    </div>

                    <div className="end-form">
                        <input className='end-form input:jacket' type='checkbox' />
                        <p className='title-label'>NÃO FINALIZADO</p>


                        <button type='submit' className='button-submit'>
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