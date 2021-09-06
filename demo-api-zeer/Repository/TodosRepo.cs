using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using demo_api_zeer.Managers;
using demo_api_zeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_api_zeer.Repository
{
    public class TodosRepo
    {
        public DynamoDBConnectionManager _connectionManager;

        public TodosRepo()
        {
            _connectionManager = new DynamoDBConnectionManager();
            _connectionManager.connection();
        }

        // Get All Todos
        public async Task<IEnumerable<TodosModel>> GetAllTodos()
        {
            try
            {
                var res = await _connectionManager.context
                            .ScanAsync<TodosModel>(new List<ScanCondition>())
                            .GetRemainingAsync();
                return res;
            }
            catch (AmazonDynamoDBException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // Get one Todo by ID
        public async Task<TodosModel> GetTodoByID(String id)
        {
            try
            {
                var res = await _connectionManager.context.LoadAsync<TodosModel>(id);
                return res;
            }
            catch (AmazonDynamoDBException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // Create / Add New Todo
        public async Task<TodosModel> AddNewTodo(TodosModel newTodo)
        {
            try
            {
                await _connectionManager.context.SaveAsync(newTodo);
                var res = await _connectionManager.context.LoadAsync<TodosModel>(newTodo.Id);
                return res;
            }
            catch (AmazonDynamoDBException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // Update Todo
        public async Task<TodosModel> UpdateTdodo(String id, TodosModel updatedTodo)
        {
            try
            {
                if (id != updatedTodo.Id)
                {
                    return null;
                }
                var checkTodo = await _connectionManager.context.LoadAsync<TodosModel>(id);
                if (checkTodo == null)
                {
                    return null;
                }
                await _connectionManager.context.SaveAsync(updatedTodo);
                var res = await _connectionManager.context.LoadAsync<TodosModel>(updatedTodo.Id);
                return res;
            }
            catch (AmazonDynamoDBException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // Update Completed Status of Todo
        public async Task<TodosModel> UpdateCompletedStatusOfTodo(String id)
        {
            try
            {
                var todo = await _connectionManager.context.LoadAsync<TodosModel>(id);
                if (todo == null)
                {
                    return null;
                }

                todo.Completed = !todo.Completed;
                await _connectionManager.context.SaveAsync(todo);
                var updatedTodo = await _connectionManager.context.LoadAsync<TodosModel>(todo.Id);

                if (updatedTodo == null || updatedTodo.Completed != todo.Completed)
                {
                    return null;
                }
                return updatedTodo;
            }
            catch (AmazonDynamoDBException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // Delete Todo
        public async Task<TodosModel> DeleteTodo(String id)
        {
            try
            {
                var todo = await _connectionManager.context.LoadAsync<TodosModel>(id);
                if (todo == null)
                {
                    return null;
                }

                await _connectionManager.context.DeleteAsync<TodosModel>(todo.Id);
                return todo;
            }
            catch (AmazonDynamoDBException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
