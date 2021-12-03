package com.SEP3.CarRentalAPI.Controllers;

import com.SEP3.CarRentalAPI.DBRepository.CustomerRepository;
import com.SEP3.CarRentalAPI.DBRepository.EmployeeRepository;
import com.SEP3.CarRentalAPI.Model.Customer;
import com.SEP3.CarRentalAPI.exception.EmailAlreadyUsedException;
import com.SEP3.CarRentalAPI.exception.ResourceNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

@RestController
@RequestMapping("/api")
public class CustomerController
{
    @Autowired
    private CustomerRepository repository;
    @Autowired
    private EmployeeRepository employeeRepository;

    @GetMapping("/customers")
    public List<Customer> getAllCustomers()
    {
        return repository.findAll();
    }

    @GetMapping("/customers/{id}")
    public ResponseEntity<Customer> getCustomerById(@PathVariable(value = "id") Long customerId)
            throws ResourceNotFoundException
    {
        Customer customer = repository.findById(customerId)
                .orElseThrow(() -> new ResourceNotFoundException("Customer not found for this id :: " + customerId));
        return ResponseEntity.ok().body(customer);
    }

    @PostMapping("/customers")
    public Customer createCustomer(@Valid @RequestBody Customer customer) throws EmailAlreadyUsedException
    {
        if (employeeRepository.findByEmail(customer.getEmail()) != null)
        {
            throw new EmailAlreadyUsedException("Email already used");
        }
        return repository.save(customer);
    }

    @PutMapping("/customers/{id}")
    public ResponseEntity<Customer> updateCustomer(@PathVariable(value = "id") Long customerId,
                                                   @Valid @RequestBody Customer customerDetails) throws ResourceNotFoundException
    {
        Customer customer = repository.findById(customerId)
                .orElseThrow(() -> new ResourceNotFoundException("Customer not found for this id :: " + customerId));

        customer.setName(customerDetails.getName());
        customer.setEmail(customerDetails.getEmail());
        customer.setPassword(customerDetails.getPassword());
        customer.setAddress(customerDetails.getAddress());
        customer.setLicenceNumber(customerDetails.getLicenceNumber());
        final Customer updatedCustomer = repository.save(customer);
        return ResponseEntity.ok(updatedCustomer);
    }

    @DeleteMapping("/customers/{id}")
    public Customer deleteCustomer(@PathVariable(value = "id") Long customerId)
            throws ResourceNotFoundException
    {
        Customer customer = repository.findById(customerId)
                .orElseThrow(() -> new ResourceNotFoundException("Customer not found for this id :: " + customerId));

        Customer deletedCustomer = repository.getById(customerId);
        repository.deleteById(customerId);
        return deletedCustomer;
    }
}
