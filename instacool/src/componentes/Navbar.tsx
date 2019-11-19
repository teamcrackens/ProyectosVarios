import { faNewspaper,faUser } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import * as React from 'react'
import { Link } from 'react-router-dom'

const style = {
    Navbar:{
        borderBottom: 'solid 1px #aaa',
        padding : '10px 15px',
    },
    link: {
        color:'#555', 
        textDecoration:'none'
    },

    
}

export default class Navbar extends React.Component{
    public render(){
        return (
            <div style={style.Navbar}>
                <Link style={style.link} to='/app/Newsfeed'><FontAwesomeIcon icon={faNewspaper}/>Instacool</Link>
                <div style={{float:'right'}}><Link style={style.link} to='/app/Profile' > <FontAwesomeIcon icon={faUser}/><FontAwesomeIcon icon={faUser}/> Perfil</Link></div>
            </div>
        )
    }
}  