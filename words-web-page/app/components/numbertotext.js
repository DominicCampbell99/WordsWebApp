'use client'
import { useState } from "react";
import styles from "../styles/numberToText.module.css"

export default function NumberToText() {
    const [number, setNumber] = useState('');
    const [numberInTextForm, setNumberInTextForm] = useState('')
    const [error, setError] = useState(false);
    const [errormsg, setErrormsg] = useState('')

    const getTextTranslation = async () => {
        try{
            const result = await fetch(`/api/getNumberToText?number=${number}`);
            const json = await result.json();
            if(json.error === true){
                setError(true);
                setErrormsg(json.errormsg);
            }
            setNumberInTextForm(`"${json.textValue}"`);
        } catch (e){
            console.log(e);
            setError(true);
            setErrormsg("not a valid input")
        }
        
    }
    return (
        <div className={styles.container}>
            <div className={styles.borderbox}>
                {error ? (
                    <div className={styles.errorblock}>{errormsg}</div>
                ) : <div style={{width: '100%', height: '50px'}}></div>}
                <div className={styles.formGroup}>
                    <label className={styles.formLabel}>Enter a Number</label>
                    <input 
                        alt="numberinput"
                        className={`${styles.formField} ${error ? styles.error : ''}`}
                        type="number"
                        onChange={(e) => {setNumber(e.target.value); setError(false)}}
                    />
                    <button className={styles.button} onClick={() => getTextTranslation()}>Translate</button>
                </div>
                <div className={styles.translation}>Your Translation is: {numberInTextForm}</div>
            </div>
        </div>
    );
}
