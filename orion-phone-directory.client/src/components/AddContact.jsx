import styles from "../components/addcontact.module.scss";

const AddContact = () => {
    return (
        <div className={styles.addContact}>
            <div className={styles.rt37} />
            <div className={styles.flexWrapperEight}>
                <div className={styles.rt155} />
                <div className={styles.flexWrapperNine}>
                    <div className={styles.flexWrapperTwo}>
                        <p className={styles.nameSurname}>AD SOYAD</p>
                        <div className={styles.lineOne} />
                        <p className={styles.telNo}>TELEFON NO.</p>
                    </div>                    
                </div>
                <div className={styles.flexWrapperTen}>
                    ORION POS TELEFON REHBERI
                    <div className={styles.flexWrapperEleven}>
                        <div className={styles.flexWrapperSeven}>                            
                            <img
                                alt=""
                                className={styles.vector}
                                src="https://static.overlay-tech.com/assets/195dd197-f372-481e-a760-b85cd0d462af.svg"                               
                            />                            
                        </div>
                        <img
                            alt=""
                            className={styles.image11}
                            src="https://static.overlay-tech.com/assets/010fe536-860e-405c-bc6c-ce0979918aea.png"
                        />
                    </div>                   
                        
                    <div className={styles.flexWrapperThree}>
                       <p className={styles.name}>Ad</p>
                       <p className={styles.surname}>Soyad</p>
                       <p className={styles.telNo1}>Telefon No</p>
                       <div className={styles.rt93} />
                       <div className={styles.rt94} />
                       <div className={styles.rt95} /> 
                       <div className={styles.buttonsWrapper}>
                          <button className={styles.addButton}> Kisi Ekle</button>
                          <button className={styles.updateButton}>Kisiyi Guncelle</button>
                          <button className={styles.deleteButton}>Kisiyi Sil</button>
                          <button className={styles.cancelButton}>Vazgec</button>
                       </div>
                    </div>                    
                </div>                
            </div>
            <div className={styles.flexWrapperOne}>
                <div className={styles.rt19}/>
                <div className={styles.rt1} />
                <div className={styles.rt24} />
                <div className={styles.rt25} />
                <p className={styles.contacts}>Kisiler</p>
                <p className={styles.phoneDirectory}>
                    Telefon Rehberi
                </p>
                <div className={styles.downarrow1206631}>                    
                    <img
                        alt=""
                        className={styles.vectorTwo}
                        src="https://static.overlay-tech.com/assets/a6742e20-ca99-4cff-84cd-9bf2bcf536b5.svg"
                    />
                </div>
                <div className={styles.mbriaddsubmenu994981}>
                    <img
                        alt=""
                        className={styles.vectorThree}
                        src="https://static.overlay-tech.com/assets/58c3ad77-3f79-4e4f-9942-e73209bb561d.svg"
                    />
                </div>
            </div>
        </div>
    );
};

export default AddContact;