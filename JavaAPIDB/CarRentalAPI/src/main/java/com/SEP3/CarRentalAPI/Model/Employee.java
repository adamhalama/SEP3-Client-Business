package com.SEP3.CarRentalAPI.Model;

import javax.persistence.*;

@Entity
@Table(name = "employee")
public class Employee
{

	private long id;
	private String name;
	private String email;
	private String password;
	private String clearanceLevel;
	
	public Employee() {
		
	}
	
	public Employee(String name, String password, String email, String clearanceLevel) {
		this.name = name;
		this.email = email;
		this.password = password;
		this.clearanceLevel = clearanceLevel;
	}
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	
	@Column(name = "name", nullable = false)
	public String getName() {
		return name;
	}
	public void setName(String firstName) {
		this.name = firstName;
	}

	@Column(name = "email", nullable = false)
	public String getEmail() {
		return email;
	}
	public void setEmail(String emailId) {
		this.email = emailId;
	}

	@Column(name = "password", nullable = false)
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}

	@Column(name = "clearance_level", nullable = false)
	public String getClearanceLevel() {
		return clearanceLevel;
	}
	public void setClearanceLevel(String clearanceLevel) {
		this.clearanceLevel = clearanceLevel;
	}

	@Override
	public String toString() {
		return "Employee [id=" + id + ", firstName=" + name + ", password=" + password + ", emailId=" + email
				+ "]";
	}
	
}
