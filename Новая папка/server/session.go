package main

import (
	"fmt"
	//	"math/rand"
	"sync"

	_ "github.com/go-sql-driver/mysql"
)

/*
type Session struct {
	Login     string
	Useragent string
}

type SessionID struct {
	ID string
}

const sessKeyLen = 10

type SessionManager struct {
	mu       sync.RWMutex
	sessions map[SessionID]*Session
}

func NewSessManager() *SessionManager {
	return &SessionManager{
		mu:       sync.RWMutex{},
		sessions: map[SessionID]*Session{},
	}
}

*/

type Users struct {
	Login    string
	Password string
}

type SessionID struct {
	ID string
}

const sessKeyLen = 10

type SessionManager struct {
	mu       sync.RWMutex
	sessions map[SessionID]*Users
}

func NewSessManager() *SessionManager {
	return &SessionManager{
		mu:       sync.RWMutex{},
		sessions: map[SessionID]*Users{},
	}
}

func (sm *SessionManager) Auth(in *Users, out *SessionID) error {
	fmt.Println("call Auth", in)
	mysql := mysql()
	commandMySql, err := mysql.DB.Query("SELECT id FROM users WHERE nick = ? AND password = ?", in.Login, in.Password)
	if err != nil {
		fmt.Println("request not processed")
		commandMySql.Close()
		return err
	}
	if commandMySql.Next() {
		err = commandMySql.Scan(&out.ID)
		if err != nil {
			fmt.Println("error scan")
			commandMySql.Close()
			return err
		}
		fmt.Println("User at id:", out.ID)
		commandMySql.Close()
		return nil
	} else {
		// надо закрывать соединение, иначе будет течь
		commandMySql.Close()
		return err
	}
}

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------
// Projects

type ProjectSelect struct {
	Name string
	Date string
}

func (sm *SessionManager) selectProjects(in *Users, out *ProjectSelect) (error, string) {
	fmt.Println("call select projects at", in.Login)
	mysql := mysql()
	commandMySql, err := mysql.DB.Query("SELECT name, data FROM projects WHERE status = true")
	defer commandMySql.Close()
	var str string
	// Цикл по строкам,
	// используя Scan для назначения данных столбца полям структуры.
	for commandMySql.Next() {

		if err := commandMySql.Scan(&out.Name,
			&out.Date); err != nil {
			fmt.Println("eroor scan Projects")
		}
		str = str + out.Name + "|" + out.Date + "\n"
	}
	if err = commandMySql.Err(); err != nil {
		fmt.Println("eroor command mysql")
	}
	return err, str
}

//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// add project

func poiscProject(str string) bool {
	Database := mysql()
	var Bools bool
	iD22 := ""
	commandMySql, err := Database.DB.Query("SELECT id FROM projects WHERE project = ?", str)
	if err != nil {
		fmt.Println("request not processed")
	}
	if commandMySql.Next() {
		err = commandMySql.Scan(&iD22)
		if err != nil {
			fmt.Println("error scan")
		}
	}
	if iD22 == "" {
		Bools = true
	} else {
		Bools = false
	}
	// надо закрывать соединение, иначе будет течь
	commandMySql.Close()
	return Bools
}

func (sm *SessionManager) AddProject(in *SessionID, in2 *ProjectSelect) error {
	sm.mu.Lock()
	Poisc2 := poiscProject(in2.Name)
	sm.mu.Unlock()
	if Poisc2 == true {
		Database := mysql()
		result, err := Database.DB.Exec("INSERT INTO projects (`id_user_admin`, `name`, `data`, `status`) VALUES (?, ?, ?, ?)", in.ID, in2.Name, in2.Date, "true")
		if err != nil {
			return err
		}

		affected, err := result.RowsAffected()
		if err != nil {
			return err
		}
		lastID, err := result.LastInsertId()
		if err != nil {
			return err
		}
		fmt.Println("Insert - RowsAffected", affected, "ProjectId: ", lastID)
		return err
	} else {
		return nil
	}
}

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// delete project

/*
func (sm *SessionManager) poiscDeleteProject(str string ) string {
	Database := mysql()
	commandMySql, err := Database.DB.Query("SELECT id_user_admin FROM projects WHERE project = ?", str)
	if err != nil {
		fmt.Println("request not processed")
	}
	var  adminUser string
	if commandMySql.Next() {
		err = commandMySql.Scan(&adminUser)
		if err != nil {
			fmt.Println("error scan")
		}
	}
	// надо закрывать соединение, иначе будет течь
	commandMySql.Close()
	return adminUser
}
*/

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// Сведения об организации
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// вывод стран

func (sm *SessionManager) selectStrans() (error, string) {
	//fmt.Println("call select projects at", in.Login)
	mysql := mysql()
	commandMySql, err := mysql.DB.Query("SELECT name FROM country")
	defer commandMySql.Close()
	var NameStrans string
	var str string
	// Цикл по строкам,
	// используя Scan для назначения данных столбца полям структуры.
	for commandMySql.Next() {

		if err := commandMySql.Scan(&NameStrans); err != nil {
			fmt.Println("eroor scan Projects")
		}
		str = str + NameStrans + "\n"
	}
	if err = commandMySql.Err(); err != nil {
		fmt.Println("eroor command mysql")
	}
	return err, str
}

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

type oficall struct {
	full_name        string
	abbreviated_name string
	inn              string
	kpp              string
	ogrn             string
	address          string
	city             string
	okpno            string
	id_country       string
	post_manager     string
	fio_manager      string
}

func (sm *SessionManager) selectOfical(out *oficall) (error, string) {

	mysql := mysql()
	commandMySql, err := mysql.DB.Query("SELECT * FROM Information_organization")
	defer commandMySql.Close()
	var str string
	// Цикл по строкам,
	// используя Scan для назначения данных столбца полям структуры.
	for commandMySql.Next() {

		if err := commandMySql.Scan(&out.full_name, &out.abbreviated_name,
			&out.inn, &out.kpp, &out.ogrn,
			&out.city, &out.okpno, &out.id_country,
			&out.post_manager, &out.fio_manager); err != nil {
			fmt.Println("eroor scan Projects")
		}

		str = out.full_name + "|" + out.abbreviated_name + "|" + out.inn + "|" + out.kpp + "|" + out.ogrn + "|" + out.city + "|" + out.okpno + "|" + out.post_manager + "|" + out.fio_manager
	}
	if err = commandMySql.Err(); err != nil {
		fmt.Println("eroor command mysql")
	}
	return err, str
}

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// select id struns

func selectStransid(in string) (error, string) {
	//fmt.Println("call select projects at", in.Login)
	mysql := mysql()
	commandMySql, err := mysql.DB.Query("SELECT id FROM country WHERE name = ?", in)
	defer commandMySql.Close()
	var str string
	var IDstruns string
	// Цикл по строкам,
	// используя Scan для назначения данных столбца полям структуры.
	for commandMySql.Next() {

		if err := commandMySql.Scan(&IDstruns); err != nil {
			fmt.Println("eroor scan Projects")
		}
		str = IDstruns
	}
	if err = commandMySql.Err(); err != nil {
		fmt.Println("eroor command mysql")
	}
	return err, str
}

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// insert oficall

func (sm *SessionManager) AddOfical(in *oficall) error {
	Database := mysql()
	result, err := Database.DB.Exec("INSERT INTO projects (`full_name`, `abbreviated_name`, `inn`, `kpp`, `ogrn`, `city`, `okpno`, `id_country`, `post_manager`, `fio_manager`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", in.full_name, in.abbreviated_name, in.inn, in.kpp, in.ogrn, in.city, in.okpno, in.id_country, in.post_manager, in.fio_manager)
	if err != nil {
		return err
	}

	affected, err := result.RowsAffected()
	if err != nil {
		return err
	}
	lastID, err := result.LastInsertId()
	if err != nil {
		return err
	}
	fmt.Println("Insert - RowsAffected", affected, "ProjectId: ", lastID)
	return err
}

//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
