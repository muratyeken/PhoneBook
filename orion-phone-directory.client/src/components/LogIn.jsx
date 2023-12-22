import styles from "../components/login.module.scss"

const logIn = () => {
    return (
        <div className={styles.logIn}>
            <div className={styles.flexWrapperOne}>
                <p className={styles.username}>Kullanici Adi:</p>
                <div className={styles.rt161} />
            </div>
            <div className={styles.flexWrapperTwo}>
                <p className={styles.password}>Sifre:</p>
                <div className={styles.rt160} />
            </div>
            <div className={styles.flexWrapperThree}>
                <label className={styles.remindMe}>
                    <input type="checkbox" className={styles.remindMeCheckbox} />
                    Beni Hatirla
                </label>
                
            </div>

            <div className={styles.buttonsWrapper}>
                <button className={styles.signUpButton}>Sign Up</button>
                <button className={styles.loginButton}>Login</button>
                <button className={styles.forgotPasswordButton}>Forgot Password</button>
            </div>

            <p className={styles.title}>
                ORIONPOS TELEFON REHBERI
            </p>
        </div>
    );
};



export default logIn;